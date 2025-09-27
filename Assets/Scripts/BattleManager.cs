using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BattleManager : MonoBehaviour
{
    public static BattleManager inst;

    public Transform turnIconP;
    public GameObject turnIcon;
    private void Awake()
    {
        if (inst == null) inst = this;
    }

    List<Character> charaList = new List<Character>();
    public void AddChara(Character character)
    {
        charaList.Add(character);
    }

    public void BattleStart()
    {
        SetTurn(10);
        Player.inst.Reload();
    }
    void SetTurn(int turns=1)
    {
        for (int i = 0; i < turns; i++)
        {
            bool f = false;

            while (true)
            {
                f = false;
                foreach (Character character in charaList)
                {
                    character.charaStat.ACTCount += Mathf.Max(character.charaStat.ACT, 1);
                    f = f ? f : character.charaStat.ACTCount >= 100;
                }
                if (f)
                {
                    charaList.Where(c => c.charaStat.ACTCount >= 100)
                        .ToList()
                        .ForEach(c =>
                        {
                            c.charaStat.ACTCount -= 100;
                            var t = Instantiate(turnIcon, turnIconP);
                            t.GetComponent<TurnIcon>().Init(c);
                        });

                    break;
                }
            }
        }

    }

    public void TurnStart()
    {

    }
    public void TurnEnd()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { BattleStart(); }
    }
}

[System.Serializable]
public class ActionStat
{
    public int DMG;
    public int armor;
    public ActionStat(ActionStat copy)
    {
        this.DMG = copy.DMG;
        this.armor = copy.armor;
    }
}

[System.Serializable]
public class Action
{
    public ActionStat actionStat;
    public Character owner;
    public List<Character> target;
}
