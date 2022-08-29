using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;
    public Camera cam;

    [SerializeField] Image fadePanel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fadePanel.DOFade(0, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
