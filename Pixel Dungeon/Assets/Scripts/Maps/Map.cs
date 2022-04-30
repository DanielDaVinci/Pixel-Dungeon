using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] protected GameObject platformPrefab;
    protected StartPlatform startPlatform;
    public Dictionary<Vector3Int, Platform> platforms;

    protected void Start()
    {
        
    }
}
