using UnityEngine;

public class DamageDealer : LiMono
{
    [SerializeField] protected int attackDamage = 1;

    protected void DealDamage(Collider collider) {
        DamageReceiver damageReceiver = collider.GetComponentInChildren<DamageReceiver>();
        
        if(damageReceiver == null) return;
        DealDamage(damageReceiver);
    }

    protected void DealDamage(DamageReceiver damageReceiver)
    {
        damageReceiver.TakeDamage(attackDamage);
    }
}