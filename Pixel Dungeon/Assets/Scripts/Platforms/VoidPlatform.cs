using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class VoidPlatform : Platform
{
    protected override void SetProperties()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("Materials/VoidPlatformMaterial");
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }

    private void OnMouseUpAsButton()
    {
        if (UIInfo.MouseOnUI)
            return;

        SimplePlatform newScript = gameObject.AddComponent<SimplePlatform>();
        newScript.Copy(this);
        Destroy(this);
    }
}
