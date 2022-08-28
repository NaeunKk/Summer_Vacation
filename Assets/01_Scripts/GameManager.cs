using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static float curSpeed;
    public static int curHp;
    public static int maxHp;
    public static float curDamage;
    public static float point;
    public int healPotionNum;
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
