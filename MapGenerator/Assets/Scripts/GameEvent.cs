public static class GameEvent
{
    public delegate void PlayerTakeDamage(int damage);
    public static PlayerTakeDamage OnPlayerTakeDamage;
}
