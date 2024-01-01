using UnityEngine;

public class BulletDL : DamageDealer
{
    [SerializeField] protected EntityType dealer;

    protected void OnTriggerEnter(Collider collider)
    {
        CollideAndDealDamage(EntityType.Player, collider, "Monster");
        CollideAndDealDamage(EntityType.Monster, collider, "Player");
        if(!NotCollideWithDealer(collider)) return;
        Destroy(transform.parent.gameObject);
    }

    public void SetDealer(EntityType dealer)
    {
        this.dealer = dealer;
    }

    protected void CollideAndDealDamage(EntityType dealer, Collider collider, string tag) {
        if(this.dealer == dealer && collider.CompareTag(tag)) {
            DealDamage(collider);
        }
    }

    protected bool NotCollideWithDealer(Collider collider)
    {
        if(dealer == EntityType.Player && collider.CompareTag("Player")) return false;
        if(dealer == EntityType.Monster && collider.CompareTag("Monster")) return false;
        return true;
    }
}