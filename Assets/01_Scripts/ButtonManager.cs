using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void BuyHealPotion()
    {
        if (JsonManager.instance.Data.point >= 7)
        {
            JsonManager.instance.Data.healPotionNum++;
            JsonManager.instance.Data.point -= 7;
            JsonManager.instance.Save();
        }
    }

    public void BuySpeedUp()
    {
        if (JsonManager.instance.Data.point >= 15)
        {
            JsonManager.instance.Data.curSpeed++;
            JsonManager.instance.Data.point -= 15;
            JsonManager.instance.Save();
        }
    }
    public void BuyDamageUp()
    {
        if (JsonManager.instance.Data.point >= 12)
        {
            JsonManager.instance.Data.curDamage++;
            JsonManager.instance.Data.point -= 12;
            JsonManager.instance.Save();
        }
    }
    public void BuyMaxHp()
    {
        if (JsonManager.instance.Data.point >= 9)
        {
            JsonManager.instance.Data.maxHp++;
            JsonManager.instance.Data.point -= 9;
            JsonManager.instance.Save();
        }
    }
}
