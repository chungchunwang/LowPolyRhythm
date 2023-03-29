using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointSystem : MonoBehaviour
{
    [SerializeField] TMP_Text[] pointLabels;
    int currentPoints = 0;
    public void addPoints(int amount){
        currentPoints += amount;
        updatePointLabels();
    }
    public void removePoints(int amount){
        currentPoints -= amount;
        updatePointLabels();
    }
    void updatePointLabels(){
        foreach(TMP_Text label in pointLabels){
            label.text = currentPoints.ToString();
        }
    }
    void Start()
    {
        updatePointLabels();
    }
    
}
