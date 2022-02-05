using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int healthMax = 30;
    public int health = 30;
    public Slider SliderHealth;

    private Rigidbody2D _rb;

    private bool immunity = false;

    void Start()
    {
        GameEvent.OnPlayerTakeDamage += OnPlayerTakeDamage;
        _rb = GetComponent<Rigidbody2D>();
        health = healthMax;
        SliderHealth.maxValue = healthMax;
        SliderHealth.value = health;
    }

    public void SetMaximumHealth()
    {
        health = healthMax;
        SliderHealth.value = health;
    }

    private void OnPlayerTakeDamage(int damage, Vector2 pushVector)
    {
        if (immunity == false)
        {
            _rb = GetComponent<Rigidbody2D>();
            health -= damage;
            _rb.AddForce(pushVector);
            SliderHealth.value = health;
            immunity = true;
            StartCoroutine(cancelImmunity());
            if (health <= 0)
            {
                GameEvent.OnPlayerDies?.Invoke();
            }
        }
    }

    private IEnumerator cancelImmunity()
    {
        yield return new WaitForSeconds(0.8f);
        immunity = false;
    }

}
