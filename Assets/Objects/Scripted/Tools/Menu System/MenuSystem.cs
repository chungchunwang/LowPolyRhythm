using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] GameObject[] Menus;
    [SerializeField] Button[] Buttons;
    
    private void Start() {
        for(int i = 0; i<Buttons.Length;i++){
            int passIndex = i;
            Buttons[i].onClick.AddListener(delegate{setMenu(passIndex);});
            Menus[i].SetActive(false);
        }
        Menus[0].SetActive(true);
    }
    
    private void setMenu(int index){
        for(int i = 0; i<Menus.Length;i++){
            Menus[i].SetActive(i == index);
        }
    }
}
