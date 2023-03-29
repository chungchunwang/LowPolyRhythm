using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSystem : MonoBehaviour
{
    [SerializeField] InputActionReference menuButton;
    [SerializeField] GameObject menuControllers;
    [SerializeField] GameObject gameControllers;
    [SerializeField] GameObject menu;
    // Start is called before the first frame update
    private void OnEnable() {
        menu.SetActive(false);
        menuControllers.SetActive(false);
        gameControllers.SetActive(true);
        menuButton.action.performed += onMenuButtonClicked;
    }
    private void OnDisable() {
        menuButton.action.performed -= onMenuButtonClicked;
    }
    public void onMenuButtonClicked(InputAction.CallbackContext obj){
        toggleMenuAndGame();
    }
    public void toggleMenuAndGame()
    {
        menu.SetActive(!menu.activeSelf);
        menuControllers.SetActive(!menuControllers.activeSelf);
        gameControllers.SetActive(!gameControllers.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
