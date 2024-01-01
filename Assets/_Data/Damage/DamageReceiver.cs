using UnityEngine;

public class DamageReceiver : LiMono
{
    [SerializeField] protected int currentHP = 10;

    public int CurrentHP => currentHP;

    [SerializeField] protected int maxHP = 10;

    public int MaxHP => maxHP;

    public void TakeDamage(int damage) {
        currentHP -= damage;
    }
}