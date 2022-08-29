using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float delay = 0.2f;
    [SerializeField] private int attackCount = 0;
    [SerializeField] Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(attackCount);

            // AttackAnim();
            if (attackCount == 0)
            {
                anim.SetBool("isSwingF", true);
                //Debug.Log(attackCount);
            }
            else if (attackCount == 1)
            {
                anim.SetBool("isSwingS", true);
                anim.SetBool("isSwingF", false);
            }
            else if (attackCount == 2)
            {
                anim.SetBool("isSwingT", true);
                anim.SetBool("isSwingS", false);
            }
            else if(attackCount >= 3)
            {
                anim.SetBool("isSwingF", true);
                anim.SetBool("isSwingT", false);
                attackCount = 0;
            }
            
            attackCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().hp -= JsonManager.instance.Data.curDamage;
        }
    }
}
