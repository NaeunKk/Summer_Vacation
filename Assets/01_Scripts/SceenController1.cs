using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceenController1 : MonoBehaviour
{
    private void Awake()
    {

        var obj = FindObjectsOfType<SceenController1>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
