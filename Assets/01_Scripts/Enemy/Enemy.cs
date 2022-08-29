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
    [SerializeField] protected float attackDelay;
    protected float point = 10;

    [SerializeField] Vector2 size;
    [SerializeField] LayerMask playerLayer;
    private float curSpeed;
    private int nextMove;
    private int prevMove;
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
        //Debug.Log(hit);
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
        JsonManager.instance.Data.point += point;
        JsonManager.instance.Save();
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
        if(collision.gameObject.CompareTag("Player"))
        {
            JsonManager.instance.Data.curHp -= 1;
            StartCoroutine("Attack");
        }
        if (collision.collider.CompareTag("Wall"))
        {

        }
    }
    protected void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StopCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);
            JsonManager.instance.Data.curHp -= damage;
            JsonManager.instance.Save();
        }
    }
}
