using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    [SerializeField] Player player;
    public int moneyToLevelUp = 10;
    public int moneyPerLevel = 5;
    public int stoneToLevelUp = 3;
    public int stonePerLevel = 1;
    [SerializeField] ItemUI itemUI;
    [SerializeField] ShowStats showStats;
    int point;

    [SerializeField] TextMeshProUGUI pointInfor;
    [SerializeField] TextMeshProUGUI stoneInfor;
    [SerializeField] TextMeshProUGUI levelUpInfor;

    void Start()
    {
        point = 0;
        moneyToLevelUp = 5;
        stoneToLevelUp = 3;
        levelUpInfor.text = moneyToLevelUp.ToString() + " gold + " + stoneToLevelUp.ToString()+" stone";
        pointInfor.text = point.ToString();
    }

    private void Update()
    {
        stoneInfor.text = player.upgradeStones.ToString();
    }
    public void IncreaseAppleHealed()
    {
        if (point > 0 && player.isDead == true)
        {
            SetPoint(-1);
            player.appleHealed += 1;
        }
    }
    public void IncreaseSpeed()
    {
        if (point > 0 && player.isDead == true)
        {
            SetPoint(-1);
            player.speed += 0.5f;
            showStats.GetStats();
        }
    }
    public void LevelUp()
    {
        if (player.moneys >= moneyToLevelUp && player.upgradeStones >= stoneToLevelUp && player.isDead == true && player.moneys - moneyToLevelUp >= 0)
        {
            SetPoint(1);
            moneyToLevelUp += moneyPerLevel;
            stoneToLevelUp += stonePerLevel;
            player.ResetMoney(moneyToLevelUp);
            player.upgradeStones -= stoneToLevelUp;
            itemUI.CoinUpdate();
            levelUpInfor.text = moneyToLevelUp.ToString() + " gold + " + stoneToLevelUp.ToString() + " stone";

        }
    }
    public void IncreaseAmor()
    {
        if (point > 0 && player.isDead == true)
        {
            SetPoint(-1);
            player.amor += 1;
            showStats.GetStats();
        }
    }
    void SetPoint(int i)
    {
        if (i == 1)
        {
            point++;
        }
        else if (i == -1)
        {
            point--;
        }
        pointInfor.text = point.ToString();
    }
}
