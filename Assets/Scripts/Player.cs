using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    public static Player inst;
    public Transform bulletP;
    public GameObject bullet;
    private void Awake()
    {
        if (inst == null) inst = this;
    }

    public void Reload()
    {
        charaStat.discardpile.AddRange(charaStat.cylinder);
        List<Bullet> draw= new List<Bullet>(charaStat.drawpile.Sample(6).Shuffle());
        charaStat.cylinder = draw;
        charaStat.drawpile.RemoveList(draw);

        foreach(var b in charaStat.cylinder)
        {
            var i = Instantiate(bullet, bulletP);
            i.GetComponent<BulletIcon>().Init(b);
        }
    }
}
