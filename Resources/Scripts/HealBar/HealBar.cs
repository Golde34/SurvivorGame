using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    Slider _healthSlider;
    public IHero hero { get; set; }
    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;
    }
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }
    private void Update()
    {
        if(hero != null)
        {
            SetHealth(hero.currentHealth);
        }
    }
    public void SetHealth(float health)
    {
      
        _healthSlider.value = health;
    }   

}
