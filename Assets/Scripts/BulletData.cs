using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/BulletData")]
public class BulletData : ScriptableObject
{
    public string bulletName;
    [TextArea(6, 20)] public string bulletInfo;
    public GameObject manager;
    public Sprite bulletImage;
    public ActionStat actionStat;
    public TargetType targetType;
    public ActionStat actionStat_self;
}

public enum TargetType { single,all,random}
