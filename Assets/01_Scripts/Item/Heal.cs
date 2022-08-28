using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour, IItem
{
    public void Use()
    {
        GameManager.curHp += 2;
    }
    
}
