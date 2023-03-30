using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterHealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthTxt;
    public Image healthBarImage;
    float health, maxHealth;
    float lerpSpeed;
    Monster monster;

    private void Awake()
    {
        monster = GetComponent<Monster>();
    }
    void Start()
    {
        maxHealth = monster.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarImage == null)
            return;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFilter();
        ColorChange();
    }

    void HealthBarFilter()
    {
        health = monster.health;
        healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, (health / maxHealth), lerpSpeed);
        healthTxt.text = health.ToString() + " / " + maxHealth;
    }

    void ColorChange()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBarImage.color = healthColor;
    }
}
