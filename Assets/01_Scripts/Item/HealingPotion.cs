using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    Heal heal;

    void Start()
    {
        heal = GetComponent<Heal>();
    }

    void Update()
    {
        if(GameManager.instance.healPotionNum >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                heal.Use();
            }
        }
    }
}
