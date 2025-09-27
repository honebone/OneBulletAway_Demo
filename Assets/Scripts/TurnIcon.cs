using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnIcon : MonoBehaviour
{
    public Image image;
    Character character;
    public void Init(Character chara)
    {
        character = chara;
        image.sprite=chara.charaStat.image;
    }
}
