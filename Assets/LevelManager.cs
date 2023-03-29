using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    uint currentSelectedLevel = 0;
    [SerializeField] uint numberOfLevels = 1;
    [SerializeField] Button[] incrementButtons;
    [SerializeField] Button[] decrementButtons;
    [SerializeField] Button[] playButtons;
    [SerializeField] String[] levelSceneNames;
    [SerializeField] TMP_Text[] levelLabels;
    public bool setLevel(uint levelNumber){
        if(levelNumber>=numberOfLevels) return false;
        currentSelectedLevel = levelNumber;
        updateUI();
        return true;
    }
    public bool decrementLevel(){
        if(!isMin()){
            currentSelectedLevel--;
            updateUI();
            return true;
        }
        return false;
    }
    public bool incrementLevel(){
        if(!isMax()){
            currentSelectedLevel++;
            updateUI();
            return true;
        }
        return false;
    }
    public bool isMax(){
        return currentSelectedLevel == numberOfLevels-1;
    }
    public bool isMin(){
        return currentSelectedLevel == 0;
    }
    void updateUI()
    {
        updateInteractables();
        UpdateLabels();
    }

    private void UpdateLabels()
    {
        foreach (TMP_Text txt in levelLabels)
        {
            txt.text = currentSelectedLevel.ToString();
        }
    }

    private void updateInteractables()
    {
        if (currentSelectedLevel < numberOfLevels - 1)
        {
            foreach (Button btn in incrementButtons)
            {
                btn.interactable = true;
            }
        }
        else
        {
            foreach (Button btn in incrementButtons)
            {
                btn.interactable = false;
            }
        }
        if (currentSelectedLevel > 0)
        {
            foreach (Button btn in decrementButtons)
            {
                btn.interactable = true;
            }
        }
        else
        {
            foreach (Button btn in decrementButtons)
            {
                btn.interactable = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Button btn in incrementButtons){
            btn.onClick.AddListener(()=>incrementLevel());
        }
        foreach(Button btn in decrementButtons){
            btn.onClick.AddListener(()=>decrementLevel());
        }
        foreach (Button btn in playButtons)
        {
            btn.onClick.AddListener(() => playLevel());
        }
        updateUI();
    }

    private void playLevel()
    {
        SceneManager.LoadScene(levelSceneNames[currentSelectedLevel]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
