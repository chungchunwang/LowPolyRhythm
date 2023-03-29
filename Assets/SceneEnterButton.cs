using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneEnterButton : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] int level;
    [SerializeField] string title;
    [SerializeField][Multiline] string description;
    [SerializeField] Button button;
    [SerializeField] TMP_Text titleLabel;
    [SerializeField] TMP_Text descriptionLabel;
    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(enterScene);
        titleLabel.text = $"Level {level.ToString()}: {title}";
        descriptionLabel.text = description;
    }

    private void enterScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, Camera.main.transform.rotation.eulerAngles.y, transform.rotation.z);
    }
}
