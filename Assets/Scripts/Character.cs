using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<BulletData> bullets_test;
    public CharaStat charaStat;

    private void Start()//–{“–‚ÍInit
    {
        foreach(var bullet in bullets_test)
        {
            var b=Instantiate(bullet.manager,transform);
            charaStat.deck.Add(b.GetComponent<Bullet>().Init(bullet));
        }

        charaStat.HP = charaStat.maxHP;
        charaStat.drawpile=new List<Bullet>(charaStat.deck);

        BattleManager.inst.AddChara(this);
    }

    public virtual void TurnStart() { }
    public virtual void TurnEnd() { }

    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) { }
        else if (Input.GetMouseButtonDown(1)) { InfoText.inst.SetInfo(charaStat.GetInfo()); }
    }
}

[System.Serializable]
public class CharaStat
{
    public Sprite image;
    public int maxHP;
    public int maxArmor;
    public int ACT;
    public List<Bullet> deck = new List<Bullet>();

    public int HP;
    public int armor;
    public int ACTCount;

    public List<Bullet> drawpile = new List<Bullet>();
    public List<Bullet> cylinder = new List<Bullet>();
    public List<Bullet> discardpile = new List<Bullet>();

    public string GetInfo()
    {
        string s = "";
        s += $"HP:{HP}/{maxHP}\n";
        s += $"armor:{armor}/{maxArmor}\n";
        s += $"ACT:{ACT}\n";
        s += $"ACTCount:{ACTCount}\n";
        return s;
    }
}
