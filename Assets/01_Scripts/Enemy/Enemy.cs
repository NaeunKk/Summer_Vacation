using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;

    [SerializeField] private float hp = 3;
    [SerializeField] protected float defaultSpeed = 3.5f;
    [SerializeField] protected float hitSpeed = 2.5f;
    private float curSpeed;
    SpriteRenderer sr;

    void Start()
    {
        player = GameManager.instance.player;
        sr = GetComponent<SpriteRenderer>();
        curSpeed = defaultSpeed;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 moveDir = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * curSpeed * Random.Range(0.9f, 1.1f));
        if (transform.position.x - player.position.x < 0)
            sr.flipX = true;
        else 
            sr.flipX = false;

        transform.position = moveDir;
    }
}
