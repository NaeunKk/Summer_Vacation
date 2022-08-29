using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    #region move
    [Header("move")]
    [SerializeField] private float minSpeed;
    //[SerializeField] private Vector2 limitPos;
    #endregion
    #region hp
    [Header("hp")]
    //[SerializeField] TextMeshProUGUI hpTxt;
    #endregion
    #region damage
    [Header("damage")]
    [SerializeField] float minDamage;
    #endregion
    //[SerializeField] TextMeshProUGUI naeun;
    [Header("±× ¿Ü")] 
    [SerializeField] Animator anim;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Start()
    {
        JsonManager.instance.Data.maxHp = 5;
        JsonManager.instance.Data.curHp = JsonManager.instance.Data.maxHp;
        JsonManager.instance.Data.curSpeed = minSpeed;
        JsonManager.instance.Data.curDamage = minDamage;


    }

    void Update()
    {
        Move();
        if(JsonManager.instance.Data.curHp > JsonManager.instance.Data.maxHp) 
            JsonManager.instance.Data.curHp = JsonManager.instance.Data.maxHp;
    }

    private void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDir.Normalize();
        rb.velocity = moveDir * JsonManager.instance.Data.curSpeed;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(JsonManager.instance.Data.curSpeed >= 7)
        {
            JsonManager.instance.Data.curSpeed = 7;
        }
    }

}
