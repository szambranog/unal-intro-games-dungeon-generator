using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int healthMax = 30;
    public int health;
    public Slider SliderHealth;

    void Start()
    {
        GameEvent.OnPlayerTakeDamage += OnPlayerTakeDamage;
        health = healthMax;
        SliderHealth.maxValue = healthMax;
    }
    private void OnPlayerTakeDamage(int damage)
    {
        health -= damage;
        SliderHealth.value = health;

    }
}
