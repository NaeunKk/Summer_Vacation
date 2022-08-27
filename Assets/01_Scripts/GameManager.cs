using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;
    public Camera cam;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
