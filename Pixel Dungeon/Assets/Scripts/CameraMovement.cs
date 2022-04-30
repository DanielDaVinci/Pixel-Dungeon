using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;

    private bool mouseLMBActive;       // Left mouse button
    private Vector3 startPosition;
    private Vector3 startLMBPosition;

    private bool mouseRMBActive;       // Right mouse button
    private Vector3 startRotation;
    private Vector3 startRMBPosition;

    private void Start()
    {
        mouseLMBActive = false;
        mouseRMBActive = false;
    }
    private void Update()
    {
        // Left mouse movement
        if (mouseLMBActive)
        {
            Vector3 endLMBPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            Vector3 shiftOnScreen = (endLMBPosition - startLMBPosition) / 1000 * movementSpeed;
            Vector3 shiftInWorld = startPosition - camera.transform.TransformDirection(shiftOnScreen);
            camera.transform.localPosition = shiftInWorld;
        }

        // Right mouse movement
        if (mouseRMBActive)
        {
            Vector3 endRMBPosition = new Vector3(Input.mousePosition.y, Input.mousePosition.x, 0);
            Vector3 shiftOnScreen = (endRMBPosition - startRMBPosition) / 1000 * rotateSpeed;
            Vector3 rotateInWorld = startRotation + new Vector3(-1 * shiftOnScreen.x, shiftOnScreen.y, 0);
            camera.transform.localEulerAngles = rotateInWorld;
        }
    }

    public void onMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = camera.transform.localPosition;
            startLMBPosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            mouseLMBActive = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            startRotation = camera.transform.localEulerAngles;
            startRMBPosition = new Vector3(Input.mousePosition.y, Input.mousePosition.x, 0);
            mouseRMBActive = true;
        }
    }

    public void onMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
            mouseLMBActive = false;

        if (Input.GetMouseButtonUp(1))
            mouseRMBActive = false;
    }

    public void onMouseExit()
    {
        mouseLMBActive = false;
        mouseRMBActive = false;
    }
}