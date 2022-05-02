using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class SelectionPanel : MonoBehaviour
{
    [SerializeField] private GameObject   panelPrefab;
    [SerializeField] private GameObject[] platformsTypes;
    private void Start()
    {
        SetSize();
        CreatePanels();
    }

    private void SetSize()
    {
        float width = platformsTypes.Length * panelPrefab.GetComponent<RectTransform>().rect.width;
        if (width > GetComponent<RectTransform>().sizeDelta.x)
            GetComponent<RectTransform>().sizeDelta = new Vector2(width, 0);
    }

    private void CreatePanels()
    {
        for (int i = 0; i < platformsTypes.Length; i++)
        {
            if (platformsTypes[i] == null)
                continue;

            GameObject panelObject = Instantiate(panelPrefab, transform);
            panelObject.name = $"{platformsTypes[i].name}";
            Vector3 postionX = new Vector3(panelObject.GetComponent<RectTransform>().rect.width, 0, 0) * i + new Vector3(panelObject.GetComponent<RectTransform>().rect.width / 2, 0, 0);
            panelObject.transform.localPosition += postionX;

            Panel panel = panelObject.GetComponent<Panel>() ?? panelObject.AddComponent<Panel>();
            panel.PlatformTypePrefab = platformsTypes[i];
        }
    }
}
