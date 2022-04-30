using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : Map
{
    private bool voidMode;
    public bool VoidMode
    {
        get { return voidMode; }
        set 
        { 
            voidMode = value; 
            startPlatform.VoidMode = value;
        }
    }
    private new void Start()
    {
        platforms = new Dictionary<Vector3Int, Platform>();

        Platform.PlatformPrefab = platformPrefab;
        GameObject platform = Instantiate(platformPrefab);
        platform.transform.parent = transform;

        startPlatform = platform.AddComponent<StartPlatform>();
        startPlatform.Map = this;
        startPlatform.MapPosition = new Vector3Int(0, 0, 0);
        // Test
        startPlatform.VoidMode = true;
    }
}
