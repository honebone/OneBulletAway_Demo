using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
 public   BulletStat bulletStat;
    public Bullet Init(BulletData data)
    {
        bulletStat = new BulletStat(data);
        return this;
    }
    
}

[System.Serializable]
public class BulletStat
{
    public bool alive = true;
    public BulletData bulletData;
    public BulletStat(BulletData data)
    {
        bulletData = data;
        alive = true;
    }
}

