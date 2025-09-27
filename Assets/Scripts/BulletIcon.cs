using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletIcon : MonoBehaviour
{
    public TextMeshProUGUI text;
     Bullet bullet;
    public void Init(Bullet b)
    {
        bullet = b;
        text.text = bullet.bulletStat.bulletData.bulletName;
    }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) { }
        else if (Input.GetMouseButtonDown(1)) { InfoText.inst.SetInfo(bullet.bulletStat.bulletData.bulletInfo); }
    }
}
