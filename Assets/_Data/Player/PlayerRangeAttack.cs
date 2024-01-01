using UnityEngine;

public class PlayerRangeAttack : PlayerAttack
{
    [Header("Range Attack")]
    [SerializeField] protected Transform centerPoint;
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected WeaponType weaponType = WeaponType.RangeType;
    [SerializeField] protected float radius;

    protected override void Start()
    {
        base.Start();

        radius = Vector3.Distance(centerPoint.position, playerCtrl.AttackPoint.position);
    }

    protected void Update()
    {
        RotateFollowMouse();
    }

    protected void RotateFollowMouse()
    {
        Vector3 mousePos = InputManager.Instance.mousePos;
        Vector3 mousePosClone = new Vector3(mousePos.x, mousePos.y, 0);
        Vector3 directionToMouse = mousePosClone - centerPoint.position;
        Vector3 closestPoint = centerPoint.position + directionToMouse.normalized * radius;
        playerCtrl.AttackPoint.position = closestPoint;
        float rotZ = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        centerPoint.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
    }

    protected override void DealDamage()
    {
        base.DealDamage();
        playerCtrl.Shooting.Shoot();
    }
}