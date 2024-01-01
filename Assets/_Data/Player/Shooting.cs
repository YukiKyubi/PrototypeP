using UnityEngine;

public class Shooting : PlayerAbstract
{
    [SerializeField] protected Transform bullet;
    [SerializeField] protected Transform centerPoint;

    public void Shoot()
    {   
        GameCtrl.Instance.BulletCtrl.BulletDL.SetDealer(EntityType.Player);
        Instantiate(bullet, playerCtrl.AttackPoint.position, centerPoint.rotation);
    }
}