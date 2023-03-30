using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCooldown : MonoBehaviour
{
    DameReciverPlayer dameReciverPlayer;
    
    public Image cooldownImage;
    [SerializeField] Color a;
    [SerializeField] Color b;

    private void Start()
    {
        dameReciverPlayer = FindObjectOfType<DameReciverPlayer>();
    }
    private void Update()
    {
        if(transform != null)
        {
            CooldownFilter();
        }
    }

    void CooldownFilter()
    {

        if(gameObject.name == "Player")
        {
            Player player = GetComponent<Player>();

            cooldownImage.fillAmount = dameReciverPlayer.GetPlayerSpeed();
            cooldownImage.color = Color.Lerp(a, b, dameReciverPlayer.GetPlayerSpeed() / player.GetSpeed() );
            
        }
        else
        {
            Monster monster = GetComponent<Monster>();
            cooldownImage.fillAmount = dameReciverPlayer.GetMonsterSpeed();
            cooldownImage.color = Color.Lerp(a, b, dameReciverPlayer.GetMonsterSpeed() / monster.speed);
        }
    }
}
