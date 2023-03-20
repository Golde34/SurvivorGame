using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    Slider _healthSlider;
    TextMeshProUGUI gold;

    public IHero hero { get; set; }
    private void Awake()
    {
        gold = GameObject.FindGameObjectWithTag("GoldTextCount").GetComponent<TextMeshProUGUI>();
    }
    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;       
    }
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
       
    }
    private void Update()
    {
        if (hero != null)
        {
            SetMaxHealth(hero.Health);
            SetHealth(hero.currentHealth);
        }
    }
    public void GoldColected(int goldCollect)
    {
        gold.text = goldCollect.ToString();
    }
    public void SetHealth(float health)
    {
      
        _healthSlider.value = health;
    }   

}
