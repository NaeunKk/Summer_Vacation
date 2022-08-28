using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void BuyHealPotion()
    {
        if (GameManager.point >= 7)
            GameManager.instance.healPotionNum++;
    }

    public void BuySpeedUp()
    {
        if (GameManager.point >= 15)
            GameManager.curSpeed++;
    }
    public void BuyDamageUp()
    {
        if (GameManager.point >= 11)
            GameManager.curDamage++;
    }
    public void BuyMaxHp()
    {
        GameManager.maxHp++;
    }
}
