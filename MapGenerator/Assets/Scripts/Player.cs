using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health = 30;

    void Start()
    {
        GameEvent.OnPlayerTakeDamage += OnPlayerTakeDamage;
        
    }
    private void OnPlayerTakeDamage(int damage)
    {
        health -= damage;
    }
}
