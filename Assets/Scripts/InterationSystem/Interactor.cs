using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [ SerializeField ]private Transform _interactorSource;
    [ SerializeField ] private float _interactRange;

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Ray ray = new Ray(_interactorSource.position, _interactorSource.forward);
            if(Physics.Raycast(ray, out RaycastHit hitInfo, _interactRange)) {
                if(hitInfo.collider.gameObject.CompareTag("Interactor")) {
                    IInteractable hit = hitInfo.collider.gameObject.GetComponent<IInteractable>();
                    if(hit != null) {
                        hit.Interact();
                    }
                }
            }
        }
    }
}
