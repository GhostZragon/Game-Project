using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    TextMeshProUGUI coin;
    public Player player;
    bool isCall = false;
    int coinBefor;
    private void Awake()
    {
        coin = GetComponentInChildren<TextMeshProUGUI>();
        coin.text = player.moneys.ToString();
        coinBefor = player.moneys;

    }
    // Start is called before the first frame update

    private void Update()
    {
        CoinIncrease();
    }
    public void CoinUpdate() //cong tac
    {
        isCall = true;
    }

    void CoinIncrease()
    {
        if (isCall)
        {
            if(coinBefor < player.moneys)
            {
                if (coinBefor == player.moneys)
                {
                    isCall = false;
                }
                else
                {
                    coinBefor += 1;
                    coin.text = coinBefor.ToString();
                }
            }
            else if(coinBefor > player.moneys) 
            {
                if(coinBefor == player.moneys)
                {
                    isCall = false;
                }
                else
                {
                    coinBefor -= 1;
                    coin.text = coinBefor.ToString();
                }
            }
        }
    }
}
