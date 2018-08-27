using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonObject : MonoBehaviour {

    public class Skill
    {
        public int selfWaitTurns = 0;
        // to opponent
        public int hp = 0;
        public int fireTurns = 0;
        public int stunTurns = 0;
        public int powerUpTurns = 0;
        public int powerDownTurns = 0;
        public int defenseUpTurns = 0;
        public int defenseDownTurns = 0;
        // to self
        public int selfHp = 0;
        public int selfFireTurns = 0;
        public int selfStunTurns = 0;
        public int selfPowerUpTurns = 0;
        public int selfPowerDownTurns = 0;
        public int selfDefenseUpTurns = 0;
        public int selfDefenseDownTurns = 0;

        public Skill()
        {
            this.selfWaitTurns = 0;
            this.hp = 0;
            this.fireTurns = 0;
            this.stunTurns = 0;
            this.powerUpTurns = 0;
            this.powerDownTurns = 0;
            this.defenseUpTurns = 0;
            this.defenseDownTurns = 0;
            this.selfHp = 0;
            this.selfFireTurns = 0;
            this.selfStunTurns = 0;
            this.selfPowerUpTurns = 0;
            this.selfPowerDownTurns = 0;
            this.selfDefenseUpTurns = 0;
            this.selfDefenseDownTurns = 0;
        }
    }

    [SerializeField] public int hpMax;
    public int hp;
    private int fireTurns;
    private int stunTurns;
    private int powerUpTurns;
    private int powerDownTurns;
    private int defenseUpTurns;
    private int defenseDownTurns;

    private int fireDamage;

    public Skill[] skills;
    private int waitTurns;
    private int lastSkillId;

    // Use this for initialization
    void Start()
    {
        hp = hpMax;
        fireTurns = 0;
        stunTurns = 0;
        powerUpTurns = 0;
        powerDownTurns = 0;
        defenseUpTurns = 0;
        defenseDownTurns = 0;

        fireDamage = 20;

        waitTurns = 0;
        lastSkillId = -1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isDead()
    {
        return hp <= 0;
    }

    public void UseSkill(PersonObject opponentObjectScript)
    {
        Debug.Log(hpMax + " " + hp + " " + fireTurns + " " + stunTurns);
        Debug.Log(opponentObjectScript.hpMax + " " + opponentObjectScript.hp + " " + opponentObjectScript.fireTurns + " " + opponentObjectScript.stunTurns);

        // turn process
        if (fireTurns > 0)
        {
            fireTurns--;
            hp -= fireDamage;
        }
        if (powerUpTurns > 0)
        {
            powerUpTurns--;
        }
        if (powerDownTurns > 0)
        {
            powerDownTurns--;
        }
        if (defenseUpTurns > 0)
        {
            defenseUpTurns--;
        }
        if (defenseDownTurns > 0)
        {
            defenseDownTurns--;
        }
        if (stunTurns > 0)
        {
            stunTurns--;
            return;
        }

        // use skill
        if (waitTurns > 0)
        {
            waitTurns--;
            if (waitTurns == 0)
            {
                AddHp(skills[lastSkillId].selfHp);
                AddFireTurns(skills[lastSkillId].selfFireTurns);
                AddStunTurns(skills[lastSkillId].selfStunTurns);
                AddPowerUpTurns(skills[lastSkillId].selfPowerUpTurns);
                AddPowerDownTurns(skills[lastSkillId].selfPowerDownTurns);
                AddDefenseUpTurns(skills[lastSkillId].selfDefenseUpTurns);
                AddPowerDownTurns(skills[lastSkillId].selfDefenseDownTurns);

                opponentObjectScript.AddHp(skills[lastSkillId].hp);
                opponentObjectScript.AddFireTurns(skills[lastSkillId].fireTurns);
                opponentObjectScript.AddStunTurns(skills[lastSkillId].stunTurns);
                opponentObjectScript.AddPowerUpTurns(skills[lastSkillId].powerUpTurns);
                opponentObjectScript.AddPowerDownTurns(skills[lastSkillId].powerDownTurns);
                opponentObjectScript.AddDefenseUpTurns(skills[lastSkillId].defenseUpTurns);
                opponentObjectScript.AddPowerDownTurns(skills[lastSkillId].defenseDownTurns);
            }
        }
        else
        {
            lastSkillId = Random.Range(0, skills.Length);
            waitTurns += skills[lastSkillId].selfWaitTurns;
            if (waitTurns == 0)
            {
                AddHp(skills[lastSkillId].selfHp);
                AddFireTurns(skills[lastSkillId].selfFireTurns);
                AddStunTurns(skills[lastSkillId].selfStunTurns);
                AddPowerUpTurns(skills[lastSkillId].selfPowerUpTurns);
                AddPowerDownTurns(skills[lastSkillId].selfPowerDownTurns);
                AddDefenseUpTurns(skills[lastSkillId].selfDefenseUpTurns);
                AddPowerDownTurns(skills[lastSkillId].selfDefenseDownTurns);

                opponentObjectScript.AddHp(skills[lastSkillId].hp);
                opponentObjectScript.AddFireTurns(skills[lastSkillId].fireTurns);
                opponentObjectScript.AddStunTurns(skills[lastSkillId].stunTurns);
                opponentObjectScript.AddPowerUpTurns(skills[lastSkillId].powerUpTurns);
                opponentObjectScript.AddPowerDownTurns(skills[lastSkillId].powerDownTurns);
                opponentObjectScript.AddDefenseUpTurns(skills[lastSkillId].defenseUpTurns);
                opponentObjectScript.AddPowerDownTurns(skills[lastSkillId].defenseDownTurns);
            }
        }
    }

    public void AddHp(int hp)
    {
        this.hp += hp;
        if (this.hp > this.hpMax)
        {
            this.hp = this.hpMax;
        }
    }

    public void AddFireTurns(int fireTurns)
    {
        this.fireTurns += fireTurns;
        if (this.fireTurns < 0)
        {
            this.fireTurns = 0;
        }
    }

    public void AddStunTurns(int stunTurns)
    {
        this.stunTurns += stunTurns;
        if (this.stunTurns < 0)
        {
            this.stunTurns = 0;
        }
    }

    public void AddPowerUpTurns(int powerUpTurns)
    {
        this.powerUpTurns += powerUpTurns;
        if (this.powerUpTurns < 0)
        {
            this.powerUpTurns = 0;
        }
    }

    public void AddPowerDownTurns(int powerDownTurns)
    {
        this.powerDownTurns += powerDownTurns;
        if (this.powerDownTurns < 0)
        {
            this.powerDownTurns = 0;
        }
    }

    public void AddDefenseUpTurns(int defenseUpTurns)
    {
        this.defenseUpTurns += defenseUpTurns;
        if (this.defenseUpTurns < 0)
        {
            this.defenseUpTurns = 0;
        }
    }

    public void AddDefenseDownTurns(int defenseDownTurns)
    {
        this.defenseDownTurns += defenseDownTurns;
        if (this.defenseDownTurns < 0)
        {
            this.defenseDownTurns = 0;
        }
    }

    private void OnMouseDown()
    {
        if(DrugUse.Instance.drug != null)
        {
            switch (DrugUse.Instance.holdDrugType)
            {
                //TODO
                case 0:
                    break;
                default:
                    break;
            }
            DrugUse.Instance.UseThisDrug();
        }
    }
}
