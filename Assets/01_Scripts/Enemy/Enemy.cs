using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    private Transform player;
    AIPath aiPath;

    public static int enemyCount;
    public float hp = 3;
    [SerializeField] protected float defaultSpeed = 3.5f;
    [SerializeField] protected float hitSpeed = 2.5f;
    [SerializeField] protected float damage;
    protected float point = 10;

    [SerializeField] Vector2 size;
    [SerializeField] LayerMask playerLayer;
    private float curSpeed;
    SpriteRenderer sr;

    void Start()
    {
        player = GameManager.instance.player;
        sr = GetComponent<SpriteRenderer>();
        curSpeed = defaultSpeed;
        aiPath= GetComponent<AIPath>();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
    }

    void Update()
    {
        //Move();
        Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, playerLayer);
        Debug.Log(hit);
        if(hit != null)
        {
            aiPath.enabled = true;
        }
        else
        {

        }

        if(hp <= 0)
        {
            PoolManager.Instance.Enqueue(gameObject);
        }
    }

    private void OnDisable()
    {
        GameManager.point += point;
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

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Sword"))
        {
            hp -= GameManager.curDamage;
        }
        if (collision.collider.CompareTag("Wall"))
        {

        }
    }
}
