using Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCharater : LiMono
{
    [Header("Follow Character")]
    [SerializeField] protected Transform character;
    protected CinemachineVirtualCamera vCamera;
    protected override void Start()
    {
        base.Start();
        
        character = GameCtrl.Instance.PlayerCtrl.transform;
        vCamera = GameCtrl.Instance.CameraCtrl.cinemachineVirtualCamera;
        vCamera.Follow = character;
    }
}