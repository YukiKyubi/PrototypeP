using UnityEngine;

public class GameCtrl : LiMono
{
    private static GameCtrl instance;

    public static GameCtrl Instance => instance;

    [SerializeField] protected CameraCtrl cameraCtrl;

    public CameraCtrl CameraCtrl => cameraCtrl;

    [SerializeField] protected MapCtrl mapCtrl;

    public MapCtrl MapCtrl => mapCtrl;

    [SerializeField] protected PlayerCtrl playerCtrl;

    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] protected MonsterCtrl monsterCtrl;

    public MonsterCtrl MonsterCtrl => monsterCtrl;

    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null) Debug.LogError("Only 1 GameCtrl is allowed to exist");

        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCameraCtrl();
        LoadMapCtrl();
        LoadPlayerCtrl();
        LoadMonsterCtrl();
        LoadBulletCtrl();
    }

    protected void LoadCameraCtrl()
    {
        if(cameraCtrl != null) return;

        cameraCtrl = FindObjectOfType<CameraCtrl>();

        Debug.LogWarning(transform.name + ": Load CameraCtrl", gameObject);
    }

    protected void LoadMapCtrl()
    {
        if(mapCtrl != null) return;

        mapCtrl = FindObjectOfType<MapCtrl>();

        Debug.LogWarning(transform.name + ": Load MapCtrl", gameObject);
    }

    protected void LoadPlayerCtrl()
    {
        if(playerCtrl != null) return;

        playerCtrl = FindObjectOfType<PlayerCtrl>();

        Debug.LogWarning(transform.name + ": Load PlayerCtrl", gameObject);
    }

    protected void LoadMonsterCtrl()
    {
        if(monsterCtrl != null) return;

        monsterCtrl = FindObjectOfType<MonsterCtrl>();

        Debug.LogWarning(transform.name + ": Load MonsterCtrl", gameObject);
    }

    protected void LoadBulletCtrl()
    {
        if(bulletCtrl != null) return;

        bulletCtrl = FindObjectOfType<BulletCtrl>();

        Debug.LogWarning(transform.name + ": Load BulletCtrl", gameObject);
    }
}