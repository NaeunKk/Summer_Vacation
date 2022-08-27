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
    [SerializeField] private float speed;
    //[SerializeField] private Vector2 limitPos;
    #endregion
    #region hp
    [Header("hp")]
    public int currentHp;
    [SerializeField] private int maxHp;
    [SerializeField] TextMeshProUGUI hpTxt;
    #endregion

    [SerializeField] Animator anim;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    void Start()
    {
        currentHp = maxHp;
        hpTxt.text = $"HP : {currentHp}";
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDir.Normalize();
        rb.velocity = moveDir * speed;

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            anim.SetBool("isMoving", true);
        else
            anim.SetBool("isMoving", false);

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
