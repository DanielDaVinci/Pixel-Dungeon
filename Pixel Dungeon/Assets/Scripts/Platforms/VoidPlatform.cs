using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPlatform : Platform
{
    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load<Material>("Materials/VoidPlatformMaterial");
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
    }

    private void OnMouseUpAsButton()
    {
        SimplePlatform newScript = gameObject.AddComponent<SimplePlatform>();
        newScript.Copy(this);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asd");
    }
}
