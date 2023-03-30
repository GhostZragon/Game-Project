using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowStats : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] List<TextMeshProUGUI> statsText;
    float maxHealth, health;

    void Start()
    {
        player = FindObjectOfType<Player>();

        GetStats();
    }


    public void GetStats()
    {
        for(int i = 0;i < statsText.Count; i++)
        {
            CheckStats(statsText[i]);
        }
    }
    void CheckStats(TextMeshProUGUI obj)
    {
        string name = obj.name;
        int index = 1234;
        if (name == "MaxHp")
        {
            index = 0;
        }
        else if (name == "MaxAtk")
        {
            index = 1;
        }
        else if (name == "MaxSpd")
        {
            index = 2;
        }
        else if (name == "Amor")
        {
            index = 3;
        }
        switch (index)
        {
            case 0:
                {
                    //hp
                    var go = statsText[index].GetComponent<TextMeshProUGUI>();
                    go.text = player.maxHealth.ToString();
                    break;
                }
            case 1:
                {
                    //dame
                    var go = statsText[index].GetComponent<TextMeshProUGUI>();
                    go.text = player.dame.ToString();
                    break;
                }
            case 2:
                {
                    //speed
                    var go = statsText[index].GetComponent<TextMeshProUGUI>();
                    go.text = player.speed.ToString();
                    break;
                }
            case 3:
                {
                    //amor
                    var go = statsText[index].GetComponent<TextMeshProUGUI>();
                    go.text = player.amor.ToString();
                    break;
                }

        }

    }
}
