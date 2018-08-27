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
    public int fireTurns;
    public int stunTurns;
    public int powerUpTurns;
    public int powerDownTurns;
    public int defenseUpTurns;
    public int defenseDownTurns;

    private int fireDamage;

    public Skill[] skills;
    public int waitTurns;
    private int lastSkillId;

    [SerializeField] float buffIconPositionX;
    [SerializeField] float buffIconPositionY;
    [SerializeField] GameObject fireIcon;
    [SerializeField] GameObject stunIcon;
    [SerializeField] GameObject powerUpIcon;
    [SerializeField] GameObject powerDownIcon;
    [SerializeField] GameObject defenseUpIcon;
    [SerializeField] GameObject defenseDownIcon;
    private List<GameObject> buffIcon;
    private float buffIconHeight = -0.8f;

    [SerializeField] PersonBehavior personBehavior;

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

        fireDamage = -20;

        waitTurns = 0;
        lastSkillId = -1;

        buffIcon = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        drawBuffIcon();
    }

    public void drawBuffIcon()
    {
        for (int i = 0; i < buffIcon.Count; i++)
        {
            Destroy(buffIcon[i]);
        }
        buffIcon.Clear();
        int buffIconCount = 0;
        if (fireTurns > 0)
        {
            buffIcon.Add(Instantiate(fireIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIconCount++;
        }
        if (stunTurns > 0)
        {
            buffIcon.Add(Instantiate(stunIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIconCount++;
        }
        if (powerUpTurns > 0)
        {
            buffIcon.Add(Instantiate(powerUpIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIconCount++;
        }
        if (powerDownTurns > 0)
        {
            buffIcon.Add(Instantiate(powerDownIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIconCount++;
        }
        if (defenseUpTurns > 0)
        {
            buffIcon.Add(Instantiate(defenseUpIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIconCount++;
        }
        if (defenseDownTurns > 0)
        {
            buffIcon.Add(Instantiate(defenseDownIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIconCount++;
        }
    }

    public bool isDead()
    {
        return hp <= 0;
    }

    public void UseSkill(PersonObject opponentObjectScript)
    {
        //Debug.Log(hpMax + " " + hp + " " + fireTurns + " " + stunTurns);
        //Debug.Log(opponentObjectScript.hpMax + " " + opponentObjectScript.hp + " " + opponentObjectScript.fireTurns + " " + opponentObjectScript.stunTurns);

        bool powerUp = false;
        bool powerdown = false;
        bool defenseUp = false;
        bool defensedown = false;
        if (fireTurns > 0)
        {
            fireTurns--;
            AddHp(fireDamage);
        }
        if (powerUpTurns > 0)
        {
            powerUpTurns--;
            powerUp = true;
        }
        if (powerDownTurns > 0)
        {
            powerDownTurns--;
            powerdown = true;
        }
        if (defenseUpTurns > 0)
        {
            defenseUpTurns--;
            defenseUp = true;
        }
        if (defenseDownTurns > 0)
        {
            defenseDownTurns--;
            defensedown = true;
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
            lastSkillId = personBehavior.selectSkill();
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
        if(this.hp <= 0)
        {
            GameObject.Find("BattleManager").GetComponent<BattleManager>().CheckSomeoneDead();
        }
        GetComponentInChildren<HpManager>().UpdateHp();
        personBehavior.dropMaterial();
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
            DrugUse.Instance.UseThisDrug();
            switch (DrugUse.Instance.holdDrugType)
            {
                //TODO
                case 1:
                    AddHp(40);
                    break;
                case 2:
                    AddHp(-25);
                    AddFireTurns(-99);
                    break;
                case 3:
                    AddHp(20);
                    //AddHpByTurn(5, 10);
                    break;
                case 4:
                    AddFireTurns(-99);
                    AddStunTurns(-99);
                    AddPowerDownTurns(-99);
                    AddDefenseDownTurns(-99);
                    //AddHpByTurn(5, 10);
                    break;
                case 5:
                    //AddHpByTurn(5, 20);
                    break;
                case 6:
                    AddHp(-50);
                    break;
                case 7:
                    //AddHpByTurn(8, 15);
                    break;
                case 8:
                    AddHp(99);
                    break;
                case 9:
                    AddFireTurns(5);
                    break;
                case 10:
                    AddFireTurns(-99);
                    //AddHpByTurn(5, 10);
                    break;
                case 11:
                    //AddFrogTurn(3);
                    break;
                case 12:
                    AddPowerUpTurns(99);
                    break;
                case 13:
                    BattleManager battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
                    battleManager.enemy.AddHp((int)(-battleManager.enemy.hpMax * 0.8f));
                    battleManager.hero.AddHp((int)(-battleManager.hero.hpMax * 0.8f));
                    break;
                case 14:
                    int[] temp = { 0, 0, 0, 1, 0, 0 };
                    Bag.Instance.GetMaterial(temp);
                    break;
                default:
                    AddHp(-1);
                    break;
            }
        }
    }
}
