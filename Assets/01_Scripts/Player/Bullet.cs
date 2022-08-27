using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region 총알 움직임
    [Header("총알 움직임")]
    [SerializeField] private float speed;
    [SerializeField] Rigidbody2D rb;
    #endregion
    //[SerializeField] AudioSource fireSound;
    [SerializeField] private Vector2 limitPos;

    private void OnEnable()
    {
        //fireSound.Play();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
        Vector2 pos = transform.position;

        if (transform.position.x < -limitPos.x || transform.position.x > limitPos.x 
            || transform.position.y < -limitPos.y || transform.position.y > limitPos.y)
            PoolManager.Instance.Enqueue(gameObject);
    }
}
