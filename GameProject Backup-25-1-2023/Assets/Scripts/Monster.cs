using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
    public PlayerAndMonster monster;
    public bool isDead = false;
    [SerializeField] Animator animator;

    [SerializeField] float disappearTime = 1f;

    [Header("Base Information")]
    public string names;
    public int level;
    public float health;
    public float speed;
    public float dame;
    public float amor;
    public TextMeshProUGUI nameTxt;
    [Header("Currency")]
    public int moneys;
    public int upgradeStones;
    public GameObject FloatingTextFrefab;
    private void Awake()
    {
        animator = GameObject.Find("Animation").GetComponent<Animator>();
        //SetStats();
        RandomStats();
        //this.gameObject.SetActive(false);
    }
    private void Start()
    {
        nameTxt = GameObject.Find("MonsterNameTxt").GetComponent<TextMeshProUGUI>();
        nameTxt.text = names;
    }
    void SetStats()
    {
        level = monster.level;
        health = monster.health;
        speed = monster.speed;
        dame = monster.dame;
        amor = monster.amor;

        moneys = monster.moneys;
        upgradeStones = monster.upgradeStones;
    }

    void RandomStats()
    {
        
        health = Random.Range(10, 15)*level;
        speed = Random.Range(1f, 4f) ;
        dame = Random.Range(4, 8) * level;
        amor = Random.Range(0, 2) * level;

        moneys = Random.Range(1, 5) * level;

        upgradeStones = Random.Range(1,3) * level;
    }

    //public void ShowFloatingText(float dame)
    //{
    //    if (FloatingTextFrefab)
    //    {
    //        var go = Instantiate(FloatingTextFrefab, transform.position, Quaternion.identity,transform);
    //        go.GetComponent<TextMesh>().text = dame.ToString();
    //    }
    //}

    public void Destroy()
    {
        Destroy(gameObject, disappearTime);

        isDead = true;
        animator.SetBool("IsDead", isDead);
    }

    public float GetSpeed()
    {
        return speed;
    }
}
