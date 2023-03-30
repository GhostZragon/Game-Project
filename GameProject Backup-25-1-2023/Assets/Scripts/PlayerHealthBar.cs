using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthBar : MonoBehaviour
{
    //[SerializeField] Color maxHealthColor;
    //[SerializeField] Color minHealthColor;
    public TextMeshProUGUI healthTxt;
    public Image healthBarImage;
    float currentHealth, maxHealth;
    float lerpSpeed;
    Player player;
    DameReciverPlayer dameplayer;

    private void Awake()
    {
        healthBarImage = GameObject.Find("Player Health Bar").GetComponent<Image>();
        healthTxt = GameObject.Find("PlayerHealthTxt").GetComponent<TextMeshProUGUI>();
        player = GetComponent<Player>();
    }
    void Start()
    {
        maxHealth = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFilter();
        ColorChange();
        
    }

    void HealthBarFilter()
    {
        currentHealth = player.health;
        
        healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, (currentHealth / player.maxHealth), lerpSpeed);
        healthTxt.text = currentHealth.ToString() + " / " +player.maxHealth;
    }

    void ColorChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (currentHealth / maxHealth));
        healthBarImage.color = healthColor;
    }
}
