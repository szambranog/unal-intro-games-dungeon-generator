using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameEvent
{
    public delegate void PlayerTakeDamage(int damage, Vector2 pushVector);
    public static PlayerTakeDamage OnPlayerTakeDamage;
    public delegate void PlayerDies();
    public static PlayerDies OnPlayerDies;
    public delegate void PlayerRespawn();
    public static PlayerRespawn OnPlayerRespawn;
}
