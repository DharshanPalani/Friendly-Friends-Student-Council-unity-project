using UnityEngine;
using SaveLoad;
public class TestData {
    public string name;
    public int age;
}


public class TestSaveSystem : MonoBehaviour
{
    public string data = "{\"name\":\"Alice\",\"age\":30}";

    void Start()
    {

        TestData testData = new TestData();
        testData.name = "Joey";
        testData.age = 69;

        string jsonData = JsonUtility.ToJson(testData);

        SaveLoadSystem.CreateSave(jsonData);
        Debug.Log(SaveLoadSystem.ReadSave());  
    }
}
