using UnityEngine;

public class BulletFly : LiMono
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float distance = 10f;

    protected void Update()
    {
        Fly();
        //DestroyBullet();
    }

    protected void Fly()
    {
        transform.parent.Translate(Vector3.right * speed * Time.deltaTime);
    }

    protected void DestroyBullet()
    {
        Transform camera = GameCtrl.Instance.CameraCtrl.Camera.transform;
        float currentDistance = Vector3.Distance(camera.position, transform.parent.position);

        if(currentDistance <= distance) return;
        Destroy(transform.parent.gameObject);
    }
}