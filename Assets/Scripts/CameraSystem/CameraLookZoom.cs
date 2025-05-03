using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookZoom : MonoBehaviour
{
    public Camera playerCamera;
    public float zoomFOV = 30f;
    public float normalFOV = 60f;
    public float zoomSpeed = 5f;
    public float lookRange = 10f;

    private bool isLookingAtTarget = false;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        playerCamera.fieldOfView = normalFOV;
    }

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, lookRange))
        {
            if (hit.collider.CompareTag("ZoomTarget"))
            {
                isLookingAtTarget = true;
            }
            else
            {
                isLookingAtTarget = false;
            }
        }
        else
        {
            isLookingAtTarget = false;
        }

        float targetFOV = isLookingAtTarget ? zoomFOV : normalFOV;
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }
}
