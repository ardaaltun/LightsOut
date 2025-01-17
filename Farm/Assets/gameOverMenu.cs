﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text finalScore;

    private void Start()
    {
        finalScore.text = spawner.finalScore.ToString();
    }
    public void PlayAgain(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
