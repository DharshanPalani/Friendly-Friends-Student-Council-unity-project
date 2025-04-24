using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SayHello : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hello");
        // Destroy(gameObject);
    }
}
