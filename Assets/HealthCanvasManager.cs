using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthCanvasManager : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
    }
    public void setHealth(int health){
        text.text = health.ToString();
    }
}
