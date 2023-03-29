using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] Button homeButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button restartButton;
    [SerializeField] int homeSceneIndex;
    [SerializeField] GameSystem gameSystem;
    // Start is called before the first frame update
    void Start()
    {
        homeButton.onClick.AddListener(onHomeButtonClicked);
        continueButton.onClick.AddListener(onContinueButtonClicked);
        restartButton.onClick.AddListener(onRestartButtonClicked);
    }

    private void onRestartButtonClicked()
    {
        SceneManager.LoadScene(gameObject.scene.buildIndex);
    }

    private void onContinueButtonClicked()
    {
        gameSystem.toggleMenuAndGame();
    }

    private void onHomeButtonClicked()
    {
        SceneManager.LoadScene(homeSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
