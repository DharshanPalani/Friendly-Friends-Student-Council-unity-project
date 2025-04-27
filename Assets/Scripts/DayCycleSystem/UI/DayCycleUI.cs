using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCycleUI : MonoBehaviour
{
    public TextMeshProUGUI dayCycleText;

    public void updateDayCycleUI(string time) {
        dayCycleText.text = time;
    }
}
