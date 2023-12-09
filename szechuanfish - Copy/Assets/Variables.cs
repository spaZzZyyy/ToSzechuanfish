using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Combat Variables")]
public class Variables : ScriptableObject{
    public int enemyHp;
    public int playerHp;
    public int playerAtk;
    public int playerDef;
    public int enemyAtk;
    public int hpPotion;
}
