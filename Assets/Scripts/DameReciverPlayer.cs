using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class DameReciverPlayer : MonoBehaviour
{
    public Transform spawnPos;

    float playerSpeed;
    float playerSpeedAtTimeStart;

    float monsterSpeed;
    float monsterSpeedAtTimeStart;

    int killCount;
    public bool isSummoned = false;

    [SerializeField] float disappearTime = 3f;


    [SerializeField] List<GameObject> Enemys = new List<GameObject>();

    //int addLevel = 0;

    Player player;
    Monster monster;
    DropItem dropItem;


    private void Awake()
    {
        dropItem = GameObject.Find("DropSpawner").GetComponent<DropItem>();
        player = FindObjectOfType<Player>();
        SummonEnemy();
    }

    
    void SummonEnemy()
    {

        if(isSummoned == false )
        {
            int a = Random.Range(0, 3);
            var go = Instantiate(Enemys[a]);
            go.SetActive(true);
            go.transform.position = spawnPos.transform.position;
            //if(killCount > 3)
            //{
            //    Monster monster = go.GetComponent<Monster>();
            //    addLevel++;
            //    monster.level += addLevel;
            //    killCount = 0;
            //}
            SetSpeed(go);
            //
            isSummoned = true;
            //
        }
        else
        {
            return;
        }

        //if (enemyIndex < Enemys.Count)
        //{
        //    //var go = Instantiate(Enemys[enemyIndex], spawnPos.transform.position, Quaternion.identity, transform);
        //    Enemys[enemyIndex].SetActive(true);
        //    Enemys[enemyIndex].transform.position = spawnPos.transform.position;
        //    monster = Enemys[enemyIndex].GetComponent<Monster>();
        //    SetSpeed();
        //}
    }
    private void Update()
    {
        if(player.isDead == true)
        {
            return;
        }
        if (monster == null || monster.isDead)
        {
            Invoke("SummonEnemy", disappearTime);
            return;
        }else if (monster != null && monster.isDead == false)
        {
            //Destroy(monster.gameObject);
            //isSummoned = false;
        }

        if (monster.health <= 0 || player.health <= 0)
        {
            if (monster.health <= 0)
            {
                monster.Destroy();
                player.LootCoin(monster.moneys);
                player.EatApple();
                player.DropStone();
                dropItem.Drop(monster.moneys);
                //
                killCount++;
                
                isSummoned = false;
                //Enemys.RemoveAt(enemyIndex);
            }
            if(player.health <= 0)
            {
                player.isDead = true;
            }
            return;
        }


        if (monster == null)
            return;


        CombatSystem();
    }



    void SetSpeed(GameObject go)
    {
        monster = go.GetComponent<Monster>();
        playerSpeedAtTimeStart = player.speed;
        playerSpeed = playerSpeedAtTimeStart;

        monsterSpeedAtTimeStart = monster.speed;
        monsterSpeed = monsterSpeedAtTimeStart;
    }



    void CombatSystem()
    {
        PlayerAttack();
        MonsterAttack();
    }
    void PlayerAttack()
    {

        playerSpeed -= Time.deltaTime;
        if (playerSpeed <= 0 && player.isAttack == false)
        {
            playerSpeed = playerSpeedAtTimeStart;
            monster.health -= player.dame - monster.amor/2 ;
            //monster.ShowFloatingText(player.dame);
            player.isAttack = true;
            player.AttackAnimation();
        }
        else if (playerSpeed > 0 && player.isAttack == true)
        {
            player.isAttack = false;
        }
    }
    void MonsterAttack()
    {
        if (monster == null)
        {
            return;
        }
        monsterSpeed -= Time.deltaTime;
        if (monsterSpeed <= 0)
        {
            monsterSpeed = monsterSpeedAtTimeStart;
            player.health -= monster.dame - player.amor/2;
            player.isAttack = false;
        }
    }
    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }
    public float GetMonsterSpeed()
    {
        return monsterSpeed;
    }


}
