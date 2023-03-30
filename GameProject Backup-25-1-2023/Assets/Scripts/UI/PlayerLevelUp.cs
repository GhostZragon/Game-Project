using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLevelUp : MonoBehaviour
{
    [SerializeField] Player player;
    public int moneyToLevelUp = 5;
    public int moneyPerLevel = 5;
    [SerializeField] ItemUI itemUI;
    [SerializeField] ShowStats showStats;
    int point;
    [SerializeField] TextMeshProUGUI pointInfor;
    [SerializeField] TextMeshProUGUI levelInfor;
    [SerializeField] TextMeshProUGUI moneyInfor;
    void Start()
    {
        point = 0;
        moneyToLevelUp = 5;
        moneyInfor.text = moneyToLevelUp.ToString();
    }

    
    void Update()
    {
        levelInfor.text = player.level.ToString();
    }

    public void IncreaseHealth()
    {
        if (point > 0 && player.isDead == true)
        {
            SetPoint(-1);
            player.maxHealth += 1;
            showStats.GetStats();
        }
    }

    public void IncreaseDame()
    {
        if(point > 0 && player.isDead == true)
        {
            SetPoint(-1);
            player.dame += 1;
            showStats.GetStats();
        }
    }

    public void LevelUp()
    {
        if(player.moneys >= moneyToLevelUp && player.isDead == true && player.moneys - moneyToLevelUp >= 0)
        {
            SetPoint(1);
            moneyToLevelUp += moneyPerLevel;

            player.ResetMoney(moneyToLevelUp);

            itemUI.CoinUpdate();
            moneyInfor.text = moneyToLevelUp.ToString();

            player.level += 1;
            levelInfor.text = player.level.ToString();
        }
    }

    void SetPoint(int i)
    {
        if(i == 1)
        {
            point++;
        }
        else if(i == -1)
        {
            point--;
        }
        pointInfor.text = point.ToString();
    }
}
