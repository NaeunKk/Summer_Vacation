using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, IItem
{
    public void Use()
    {
        JsonManager.instance.Data.curHp += 2;
    }
    
}
