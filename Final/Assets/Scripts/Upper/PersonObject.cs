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

        public Skill(int selfWaitTurns, int hp, int fireTurns, int stunTurns, int powerUpTurns, int powerDownTurns, int defenseUpTurns, int defenseDownTurns,
            int selfHp, int selfFireTurns, int selfStunTurns, int selfPowerUpTurns, int selfPowerDownTurns, int selfDefenseUpTurns, int selfDefenseDownTurns)
        {
            this.selfWaitTurns = selfWaitTurns;
            this.hp = hp;
            this.fireTurns = fireTurns;
            this.stunTurns = stunTurns;
            this.powerUpTurns = powerUpTurns;
            this.powerDownTurns = powerDownTurns;
            this.defenseUpTurns = defenseUpTurns;
            this.defenseDownTurns = defenseDownTurns;
            this.selfHp = selfHp;
            this.selfFireTurns = selfFireTurns;
            this.selfStunTurns = selfStunTurns;
            this.selfPowerUpTurns = selfPowerUpTurns;
            this.selfPowerDownTurns = selfPowerDownTurns;
            this.selfDefenseUpTurns = selfDefenseUpTurns;
            this.selfDefenseDownTurns = selfDefenseDownTurns;
        }
    }

    [SerializeField] public int hpMax;
    private int hp;
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
                Add(skills[lastSkillId].selfHp, skills[lastSkillId].selfFireTurns, skills[lastSkillId].selfStunTurns, skills[lastSkillId].selfPowerUpTurns, skills[lastSkillId].selfPowerDownTurns, skills[lastSkillId].selfDefenseUpTurns, skills[lastSkillId].selfDefenseDownTurns);
                opponentObjectScript.Add(skills[lastSkillId].hp, skills[lastSkillId].fireTurns, skills[lastSkillId].stunTurns, skills[lastSkillId].powerUpTurns, skills[lastSkillId].powerDownTurns, skills[lastSkillId].defenseUpTurns, skills[lastSkillId].defenseDownTurns);
            }
        }
        else
        {
            lastSkillId = Random.Range(0, skills.Length);
            waitTurns += skills[lastSkillId].selfWaitTurns;
            if (waitTurns == 0)
            {
                Add(skills[lastSkillId].selfHp, skills[lastSkillId].selfFireTurns, skills[lastSkillId].selfStunTurns, skills[lastSkillId].selfPowerUpTurns, skills[lastSkillId].selfPowerDownTurns, skills[lastSkillId].selfDefenseUpTurns, skills[lastSkillId].selfDefenseDownTurns);
                opponentObjectScript.Add(skills[lastSkillId].hp, skills[lastSkillId].fireTurns, skills[lastSkillId].stunTurns, skills[lastSkillId].powerUpTurns, skills[lastSkillId].powerDownTurns, skills[lastSkillId].defenseUpTurns, skills[lastSkillId].defenseDownTurns);
            }
        }
    }

    public void Add(int hp, int fireTurns, int stunTurns, int powerUpTurns, int powerDownTurns, int defenseUpTurns, int defenseDownTurns)
    {
        this.hp += hp;
        this.fireTurns += fireTurns;
        this.stunTurns += stunTurns;
        this.powerUpTurns += powerUpTurns;
        this.powerDownTurns += powerDownTurns;
        this.defenseUpTurns += defenseUpTurns;
        this.defenseDownTurns += defenseDownTurns;

        if(this.hp > this.hpMax)
        {
            this.hp = this.hpMax;
        }
        if (this.fireTurns < 0)
        {
            this.fireTurns = 0;
        }
        if (this.stunTurns < 0)
        {
            this.stunTurns = 0;
        }
        if (this.powerUpTurns < 0)
        {
            this.powerUpTurns = 0;
        }
        if (this.powerDownTurns < 0)
        {
            this.powerDownTurns = 0;
        }
        if (this.defenseUpTurns < 0)
        {
            this.defenseUpTurns = 0;
        }
        if (this.defenseDownTurns < 0)
        {
            this.defenseDownTurns = 0;
        }
    }
}
