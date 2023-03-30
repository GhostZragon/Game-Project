using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using System.Threading;

public class Player : MonoBehaviour
{
    public PlayerAndMonster player;
    TextMeshProUGUI nameTxt;
    public bool isAttack = false;
    public bool isDead = false;
    Animator animator;
    [Header("Base Information")]
    public string names;
    public int level;
    public float health;
    public float speed;
    public float dame;
    public float amor;
    public float maxHealth = 0;
    [Header("Currency")]
    [SerializeField] public int moneys;
    public int upgradeStones;
    public int appleHealed = 3;
    [SerializeField] DameReciverPlayer dameReciverPlayer;
    ItemUI itemUi;

    [SerializeField] AudioSource slashSound;
    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //moneys = PlayerPrefs.GetInt("Money");
        nameTxt = GameObject.Find("PlayerNameTxt").GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
        itemUi = FindObjectOfType<ItemUI>();
        SetStats();
        maxHealth = health;
        Application.targetFrameRate = 60;

    }
    private void Start()
    {
        nameTxt.text = names;
    }

    
    //void GetStats()
    //{
    //    moneys = PlayerPrefs.GetInt("Money");
    //    level = PlayerPrefs.GetInt("Level");
    //    upgradeStones = PlayerPrefs.GetInt("UpgradeStones");
    //    speed = PlayerPrefs.GetFloat("Speed");
    //    dame = PlayerPrefs.GetFloat("Dame");
    //    health = PlayerPrefs.GetFloat("Health");
    //    amor = PlayerPrefs.GetFloat("Amor");
    //}

    void SetStats()
    {
        level = player.level;
        health = player.health;
        speed = player.speed;
        dame = player.dame;
        amor = player.amor;

        moneys = player.moneys;
        upgradeStones = player.upgradeStones;
    }
    public void LootCoin(int lootCoin)
    {
        player.moneys += lootCoin;
        moneys = player.moneys;
        //PlayerPrefs.SetInt("Money",moneys);
        itemUi.CoinUpdate();
        //SetStats();
    }
    public float GetSpeed()
    {
        return speed;
    }

    public void EatApple()
    {
        health += appleHealed;
    }
    public void Reborn()
    {
        if(isDead == true)
        {
            Monster monster = FindObjectOfType<Monster>();
            Destroy(monster.gameObject);
            dameReciverPlayer.isSummoned = false;
            isDead = false;
            //isAttack = false;
            //SetStats();
            health = maxHealth;
        }
    }
    public void DropStone(int i = 1)
    {
        upgradeStones += i;
        player.upgradeStones += i;
    }
    public void AttackAnimation()
    {
        animator.SetBool("IsAttack", true);
        Invoke("SetAttackBool", 0.8f);
        slashSound.Play();
        //if (state == true)
        //{
        //    animator.SetBool("IsAttack", true);
        //}
        //else if(state == false)
        //{
        //    Invoke("SetAttackBool", 0.8f);
        //}
    }
    void SetAttackBool()
    {
        animator.SetBool("IsAttack", false);
    }

    public void ResetMoney(int i)
    {
        player.moneys -= i;
        moneys -= i;
    }
}
