using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(BoxCollider))]
public abstract class Platform : MonoBehaviour
{
    [SerializeField] private Map map;
    [SerializeField] private Vector3Int mapPosition;

    public Platform[] LocalPlatforms;
    public static GameObject PlatformPrefab;
    public virtual bool VoidMode { get; set; }

    public Map Map
    {
        get { return map; }
        set
        {
            if (map == value)
                return;

            map = value;
            for (int i = 0; i < LocalPlatforms.Length; i++)
                if (LocalPlatforms[i] != null)
                    LocalPlatforms[i].Map = value;
        }
    }

    public Vector3Int MapPosition
    {
        get { return mapPosition; }
        set
        {
            mapPosition = value;
            if (Map.platforms.TryGetValue(mapPosition, out Platform platform))
                Map.platforms[mapPosition] = this;
            else
                Map.platforms.Add(mapPosition, this);

            for (int i = 0; i < LocalPlatforms.Length; i++)
            {
                if (Map.platforms.TryGetValue(mapPosition + IdentifyDirection(i+1), out platform))
                {
                    LocalPlatforms[i] = platform;
                    platform.LocalPlatforms[(i + LocalPlatforms.Length / 2) % LocalPlatforms.Length] = this;
                }
            }
        }
    }

    protected void Awake()
    {
        LocalPlatforms = new Platform[4];
    }

    public void Copy(Platform other)
    {
        Map = other.Map;
        MapPosition = other.MapPosition;
        LocalPlatforms = other.LocalPlatforms;
        VoidMode = other.VoidMode;
    }

    protected Vector3Int IdentifyDirection(int number)
    {
        switch (number)
        {
            case 1:
                return Vector3Int.left;
            case 2:
                return Vector3Int.forward;
            case 3:
                return Vector3Int.right;
            case 4:
                return Vector3Int.back;
            default:
                return Vector3Int.zero;
        }
    }
}