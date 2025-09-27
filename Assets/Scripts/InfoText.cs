using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static InfoText inst;

    public void Awake()
    {
        if (inst == null) inst = this;
    }

    public void SetInfo(string str)
    {
        text.text = str;
    }
    public void ResetInfo()
    {
        text.text = "";
    }
}
