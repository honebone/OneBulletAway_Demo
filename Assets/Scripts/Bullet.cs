using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BulletData bulletData;
    public Bullet Init(BulletData data)
    {
        bulletData = data;
        return this;
    }
}

