using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public bool isEnabled = false;

    void Start()
    {
        GameEvent.OnPlayerDies += OnPlayerDies;
        GameEvent.OnPlayerRespawn += OnPlayerRespawn;
        gameObject.SetActive(false);
        isEnabled = false;
    }

    private void OnPlayerDies()
    {
        gameObject.SetActive(true);
        isEnabled = true;
    }
    private void OnPlayerRespawn()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isEnabled == true)
        {
            isEnabled = false;
            GameEvent.OnPlayerRespawn?.Invoke();
        }
    }
}
