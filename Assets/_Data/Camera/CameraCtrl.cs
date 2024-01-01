using Cinemachine;
using UnityEngine;

public class CameraCtrl : LiMono
{
    [SerializeField] protected Camera _camera;

    public Camera Camera => _camera;

    public CinemachineVirtualCamera cinemachineVirtualCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
        LoadVCamera();
    }

    protected void LoadCamera()
    {
        if(_camera != null) return;

        _camera = transform.GetComponentInChildren<Camera>();

        Debug.LogWarning(transform.name + ": Load Camera", gameObject);
    }

    protected void LoadVCamera()
    {
        if(cinemachineVirtualCamera != null) return;

        cinemachineVirtualCamera = transform.GetComponentInChildren<CinemachineVirtualCamera>();

        Debug.LogWarning(transform.name + ": Load Camera", gameObject);
    }
}