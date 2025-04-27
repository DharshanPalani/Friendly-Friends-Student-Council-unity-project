using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int intellegent;
    public int health;

    public void increaseStats(int id, int reward) {
        switch(id) {
            case 1:
                intellegent += reward;
                break;
            case 2:
                health += reward;
                break;
            default:
                Debug.Log("Invalid ID");
                break;
        }
    }
}
