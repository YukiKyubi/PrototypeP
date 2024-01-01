using UnityEngine;

public class BulletCtrl : LiMono
{
    [SerializeField] protected BulletDL bulletDL;

    public BulletDL BulletDL => bulletDL;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDL();
    }

    protected void LoadDL()
    {
        if(bulletDL != null) return;

        bulletDL = GetComponentInChildren<BulletDL>();

        Debug.LogWarning(transform.name + ": Load DL", gameObject);
    }
}