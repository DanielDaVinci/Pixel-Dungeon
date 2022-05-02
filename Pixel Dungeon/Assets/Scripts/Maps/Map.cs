using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] protected GameObject startPlatformPrefab;

    protected static StartPlatform startPlatform;

    public Dictionary<Vector3Int, Platform> platforms = new Dictionary<Vector3Int, Platform>();

    protected void Start()
    {
        
    }
}
