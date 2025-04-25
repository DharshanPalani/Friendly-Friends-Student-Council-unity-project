using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private Transform _interactorSource;
    [SerializeField] private float _interactRange = 3f;
    [SerializeField] private LayerMask _interactableLayers;

    [Header("Debug")]
    [SerializeField] private bool _showDebugRay = true;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }

    private void Interact() {
        if (_showDebugRay) {
            Debug.DrawRay(_interactorSource.position, _interactorSource.forward * _interactRange, Color.green, 1f);
        }

        Ray ray = new Ray(_interactorSource.position, _interactorSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _interactRange, _interactableLayers)) {
            IInteractable interactable = hitInfo.collider.GetComponent<IInteractable>();
            if (interactable != null) {
                interactable.Interact();
            } else {
                Debug.Log($"Hit {hitInfo.collider.name}, but it doesn't implement IInteractable.");
            }
        } else {
            Debug.Log("No interactable object hit.");
        }
    }
}
