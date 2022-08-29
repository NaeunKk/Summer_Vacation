using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DontDestroyObj : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(1);
        JsonManager.instance.Save();
        TextMeshProUGUI temp = GameObject.Find("Canvas").transform.Find("Hp").GetComponent<TextMeshProUGUI>();
        temp = JsonManager.instance.statisticTxt;
    }
}
