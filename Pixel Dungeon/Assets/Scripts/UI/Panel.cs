using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent( typeof(RectTransform))]
public class Panel : MonoBehaviour, IPointerClickHandler
{
    public GameObject PlatformTypePrefab;

    void Start()
    {
        Instantiate(PlatformTypePrefab, transform);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((Platform.VoidPlatformPrefab != PlatformTypePrefab) && (MapCreator.VoidMode))
        {
            MapCreator.VoidPlatformPrefab = PlatformTypePrefab;
        }
        else
        {
            Platform.VoidPlatformPrefab = PlatformTypePrefab;
            MapCreator.VoidMode = !MapCreator.VoidMode;
        }
    }
}
