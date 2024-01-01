using UnityEngine;
using UnityEngine.Tilemaps;

public class MapCtrl : LiMono
{
    [SerializeField] protected Tilemap tilemap;

    public Tilemap Tilemap => tilemap;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTimeMap();
    }

    protected void LoadTimeMap()
    {
        if(tilemap != null) return;

        tilemap = transform.GetComponentInChildren<Tilemap>();

        Debug.LogWarning(transform.name + ": Load TileMap", gameObject);
    }
}