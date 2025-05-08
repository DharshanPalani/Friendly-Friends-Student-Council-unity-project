using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // SaveLoadSystem.CreateSave("Ts is tuff");
        Debug.Log(SaveLoadSystem.ReadSave());  
    }
}
