using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : Map
{
    private static GameObject voidPlatformPrefab;
    private static bool       voidMode;

    public static GameObject VoidPlatformPrefab
    {
        get { return voidPlatformPrefab; }
        set
        {
            voidPlatformPrefab = value;
            Platform.VoidPlatformPrefab = voidPlatformPrefab;

            if (voidMode)
            {
                VoidMode = false;
                VoidMode = true;
            }
        }
    }

    public static bool VoidMode
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
        GameObject platform = Instantiate(startPlatformPrefab, transform);

        startPlatform = platform.GetComponent<StartPlatform>() ?? platform.AddComponent<StartPlatform>();
        startPlatform.Map = this;
        startPlatform.MapPosition = new Vector3Int(0, 0, 0);
    }
}
