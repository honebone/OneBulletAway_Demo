using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    public static Player inst;
    private void Awake()
    {
        if (inst == null) inst = this;
    }
}
