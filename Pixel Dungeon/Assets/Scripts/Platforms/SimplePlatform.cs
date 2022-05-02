using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : Platform
{
    [SerializeField] private bool voidMode;
    public override bool VoidMode
    {
        get { return voidMode; }
        set
        {
            if (voidMode == value)
                return;
            voidMode = value;

            for (int i = 0; i < LocalPlatforms.Length; i++)
                if (LocalPlatforms[i] != null)
                    LocalPlatforms[i].VoidMode = voidMode;

            if (voidMode)
                CreateVoidPlatforms();
            else
                DestroyVoidPlatforms();
        }
    }

    protected override void SetProperties()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("Materials/SimplePlatformMaterial");
        transform.localScale = new Vector3(1, 1, 1);
    }

    protected void CreateVoidPlatforms()
    {
        for (int i = 0; i < LocalPlatforms.Length; i++)
        {
            if (LocalPlatforms[i] != null)
                continue;

            GameObject voidPlatform = Instantiate(VoidPlatformPrefab, transform.parent);
            voidPlatform.transform.localPosition = transform.localPosition + (Vector3)IdentifyDirection(i + 1) *
                (i % 2 == 0 ? voidPlatform.transform.GetComponent<BoxCollider>().size.x : voidPlatform.transform.GetComponent<BoxCollider>().size.y);
            LocalPlatforms[i] = voidPlatform.AddComponent<VoidPlatform>();
            LocalPlatforms[i].Map = Map;
            LocalPlatforms[i].MapPosition = MapPosition + IdentifyDirection(i + 1);
            LocalPlatforms[i].VoidMode = VoidMode;
        }
    }

    protected void DestroyVoidPlatforms()
    {
        for (int i = 0; i < LocalPlatforms.Length; i++)
        {
            if ((LocalPlatforms[i] != null) && (LocalPlatforms[i].GetComponent<VoidPlatform>()))
                DestroyImmediate(LocalPlatforms[i].gameObject);
        }
    }
}
