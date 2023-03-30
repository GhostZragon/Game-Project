using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Player or Monster")]
public class PlayerAndMonster : ScriptableObject
{
    [Header("Base Information")]
    public string names;
    public int level;
    public float health;
    public float speed;
    public float dame;
    public float amor;

    [Header("Currency")]
    public int moneys;
    public int upgradeStones;
    public int apple;
}
