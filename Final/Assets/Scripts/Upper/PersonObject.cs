using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        public int healTurns = 0;
        public int healRestore = 0;
        public int frogTurns = 0;
        // to self
        public int selfHp = 0;
        public int selfFireTurns = 0;
        public int selfStunTurns = 0;
        public int selfPowerUpTurns = 0;
        public int selfPowerDownTurns = 0;
        public int selfDefenseUpTurns = 0;
        public int selfDefenseDownTurns = 0;
        public int selfHealTurns = 0;
        public int selfHealRestore = 0;
        public int selfFrogTurns = 0;

        public Skill()
        {
            selfWaitTurns = 0;
            hp = 0;
            fireTurns = 0;
            stunTurns = 0;
            powerUpTurns = 0;
            powerDownTurns = 0;
            defenseUpTurns = 0;
            defenseDownTurns = 0;
            healTurns = 0;
            healRestore = 0;
            frogTurns = 0;
            selfHp = 0;
            selfFireTurns = 0;
            selfStunTurns = 0;
            selfPowerUpTurns = 0;
            selfPowerDownTurns = 0;
            selfDefenseUpTurns = 0;
            selfDefenseDownTurns = 0;
            selfHealTurns = 0;
            selfHealRestore = 0;
            selfFrogTurns = 0;
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
    public int healTurns;
    public int frogTurns;

    private int fireDamage;
    private int healRestore;
    private int powerUpFactor;

    public Skill[] skills;
    public int waitTurns;
    [HideInInspector]public int lastSkillId;

    [SerializeField] float buffIconPositionX;
    [SerializeField] float buffIconPositionY;
    [SerializeField] GameObject fireIcon;
    [SerializeField] GameObject stunIcon;
    [SerializeField] GameObject powerUpIcon;
    [SerializeField] GameObject powerDownIcon;
    [SerializeField] GameObject defenseUpIcon;
    [SerializeField] GameObject defenseDownIcon;
    [SerializeField] GameObject healIcon;
    [SerializeField] GameObject frogIcon;
    private List<GameObject> buffIcon;
    private float buffIconHeight = -0.8f;

    [SerializeField] PersonBehavior personBehavior;

    private AudioSource useMedicineAudio;
    private AudioSource useFrogAudio;
    private AudioSource useBombAudio;

    public Animator drugEffect;

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
        healTurns = 0;
        frogTurns = 0;

        fireDamage = -20;
        healRestore = 0;
        powerUpFactor = 2;

        waitTurns = 0;
        //lastSkillId = -1;
        lastSkillId = personBehavior.selectSkill();
        buffIcon = new List<GameObject>();

        useMedicineAudio = GameObject.Find("UseMedicine").GetComponent<AudioSource>();
        useFrogAudio = GameObject.Find("Frog").GetComponent<AudioSource>();
        useBombAudio = GameObject.Find("Bomb").GetComponent<AudioSource>();
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
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = fireTurns.ToString();
            buffIconCount++;
        }
        if (stunTurns > 0)
        {
            buffIcon.Add(Instantiate(stunIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = stunTurns.ToString();
            buffIconCount++;
        }
        if (powerUpTurns > 0)
        {
            buffIcon.Add(Instantiate(powerUpIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = powerUpTurns.ToString();
            buffIconCount++;
        }
        if (powerDownTurns > 0)
        {
            buffIcon.Add(Instantiate(powerDownIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = powerDownTurns.ToString();
            buffIconCount++;
        }
        if (defenseUpTurns > 0)
        {
            buffIcon.Add(Instantiate(defenseUpIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = defenseUpTurns.ToString();
            buffIconCount++;
        }
        if (defenseDownTurns > 0)
        {
            buffIcon.Add(Instantiate(defenseDownIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = defenseDownTurns.ToString();
            buffIconCount++;
        }
        if (healTurns > 0)
        {
            buffIcon.Add(Instantiate(healIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = healTurns.ToString();
            buffIconCount++;
        }
        if (frogTurns > 0)
        {
            buffIcon.Add(Instantiate(frogIcon, new Vector3(buffIconPositionX, buffIconPositionY + buffIconCount * buffIconHeight, 0), new Quaternion(0, 0, 0, 0)));
            buffIcon[buffIconCount].GetComponentInChildren<Text>().text = frogTurns.ToString();
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

        int powerUp = 1;
        bool powerdown = false;
        bool defenseUp = false;
        bool defensedown = false;
        bool cannotmove = false;
        if (fireTurns > 0)
        {
            fireTurns--;
            AddHp(fireDamage);
        }
        if (powerUpTurns > 0)
        {
            powerUpTurns--;
            powerUp = powerUpFactor;
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
        if (healTurns > 0)
        {
            healTurns--;
            AddHp(healRestore);
        }
        if (stunTurns > 0)
        {
            stunTurns--;
            cannotmove = true;
        }
        if (frogTurns > 0)
        {
            frogTurns--;
            cannotmove = true;
        }

        if(cannotmove)
        {
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
                AddDefenseDownTurns(skills[lastSkillId].selfDefenseDownTurns);
                SetHealTurns(skills[lastSkillId].selfHealTurns, skills[lastSkillId].selfHealRestore);
                AddFrogTurns(skills[lastSkillId].selfFrogTurns);

                opponentObjectScript.AddHp(skills[lastSkillId].hp * powerUp);
                opponentObjectScript.AddFireTurns(skills[lastSkillId].fireTurns);
                opponentObjectScript.AddStunTurns(skills[lastSkillId].stunTurns);
                opponentObjectScript.AddPowerUpTurns(skills[lastSkillId].powerUpTurns);
                opponentObjectScript.AddPowerDownTurns(skills[lastSkillId].powerDownTurns);
                opponentObjectScript.AddDefenseUpTurns(skills[lastSkillId].defenseUpTurns);
                opponentObjectScript.AddDefenseDownTurns(skills[lastSkillId].defenseDownTurns);
                opponentObjectScript.SetHealTurns(skills[lastSkillId].healTurns, skills[lastSkillId].healRestore);
                opponentObjectScript.AddFrogTurns(skills[lastSkillId].frogTurns);

                personBehavior.playMusic(lastSkillId);
                lastSkillId = personBehavior.selectSkill();
            }
        }
        else
        {
            //lastSkillId = personBehavior.selectSkill();
            waitTurns += skills[lastSkillId].selfWaitTurns;

            if (waitTurns == 0)
            {
                AddHp(skills[lastSkillId].selfHp);
                AddFireTurns(skills[lastSkillId].selfFireTurns);
                AddStunTurns(skills[lastSkillId].selfStunTurns);
                AddPowerUpTurns(skills[lastSkillId].selfPowerUpTurns);
                AddPowerDownTurns(skills[lastSkillId].selfPowerDownTurns);
                AddDefenseUpTurns(skills[lastSkillId].selfDefenseUpTurns);
                AddDefenseDownTurns(skills[lastSkillId].selfDefenseDownTurns);
                SetHealTurns(skills[lastSkillId].selfHealTurns, skills[lastSkillId].selfHealRestore);
                AddFrogTurns(skills[lastSkillId].selfFrogTurns);

                opponentObjectScript.AddHp(skills[lastSkillId].hp * powerUp);
                opponentObjectScript.AddFireTurns(skills[lastSkillId].fireTurns);
                opponentObjectScript.AddStunTurns(skills[lastSkillId].stunTurns);
                opponentObjectScript.AddPowerUpTurns(skills[lastSkillId].powerUpTurns);
                opponentObjectScript.AddPowerDownTurns(skills[lastSkillId].powerDownTurns);
                opponentObjectScript.AddDefenseUpTurns(skills[lastSkillId].defenseUpTurns);
                opponentObjectScript.AddDefenseDownTurns(skills[lastSkillId].defenseDownTurns);
                opponentObjectScript.SetHealTurns(skills[lastSkillId].healTurns, skills[lastSkillId].healRestore);
                opponentObjectScript.AddFrogTurns(skills[lastSkillId].frogTurns);

                personBehavior.playMusic(lastSkillId);
                lastSkillId = personBehavior.selectSkill();
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
        if (this.fireTurns > 99)
        {
            this.fireTurns = 99;
        }
    }

    public void AddStunTurns(int stunTurns)
    {
        this.stunTurns += stunTurns;
        if (this.stunTurns < 0)
        {
            this.stunTurns = 0;
        }
        if (this.stunTurns > 99)
        {
            this.stunTurns = 99;
        }
    }

    public void AddPowerUpTurns(int powerUpTurns)
    {
        this.powerUpTurns += powerUpTurns;
        if (this.powerUpTurns < 0)
        {
            this.powerUpTurns = 0;
        }
        if (this.powerUpTurns > 99)
        {
            this.powerUpTurns = 99;
        }
    }

    public void AddPowerDownTurns(int powerDownTurns)
    {
        this.powerDownTurns += powerDownTurns;
        if (this.powerDownTurns < 0)
        {
            this.powerDownTurns = 0;
        }
        if (this.powerDownTurns > 99)
        {
            this.powerDownTurns = 99;
        }
    }

    public void AddDefenseUpTurns(int defenseUpTurns)
    {
        this.defenseUpTurns += defenseUpTurns;
        if (this.defenseUpTurns < 0)
        {
            this.defenseUpTurns = 0;
        }
        if (this.defenseUpTurns > 99)
        {
            this.defenseUpTurns = 99;
        }
    }

    public void AddDefenseDownTurns(int defenseDownTurns)
    {
        this.defenseDownTurns += defenseDownTurns;
        if (this.defenseDownTurns < 0)
        {
            this.defenseDownTurns = 0;
        }
        if (this.defenseDownTurns > 99)
        {
            this.defenseDownTurns = 99;
        }
    }

    public void SetHealTurns(int healTurns, int healRestore)
    {
        if(this.healTurns == 0 || healRestore > this.healRestore)
        {
            this.healTurns = healTurns;
            this.healRestore = healRestore;
        }
        else if (healRestore == this.healRestore)
        {
            if(healTurns > this.healTurns)
            {
                this.healTurns = healTurns;
            }
        }

        if (this.healTurns < 0)
        {
            this.healTurns = 0;
        }
        if (this.healTurns > 99)
        {
            this.healTurns = 99;
        }
    }

    public void AddFrogTurns(int frogTurns)
    {
        this.frogTurns += frogTurns;
        if (this.frogTurns < 0)
        {
            this.frogTurns = 0;
        }
        if (this.frogTurns > 99)
        {
            this.frogTurns = 99;
        }
    }

    public void clearBuff()
    {
        fireTurns = 0;
        stunTurns = 0;
        powerUpTurns = 0;
        powerDownTurns = 0;
        defenseUpTurns = 0;
        defenseDownTurns = 0;
        healTurns = 0;
        frogTurns = 0;
        drawBuffIcon();
    }

    private void OnMouseDown()
    {
        if(DrugUse.Instance.drug != null)
        {
            DrugUse.Instance.UseThisDrug();
            BattleManager battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
            switch (DrugUse.Instance.holdDrugType)
            {
                case 1:
                    AddHp(40);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 2:
                    AddHp(-25);
                    AddFireTurns(-99);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 3:
                    AddHp(20);
                    SetHealTurns(5, 10);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 4:
                    AddFireTurns(-99);
                    AddStunTurns(-99);
                    AddPowerDownTurns(-99);
                    AddDefenseDownTurns(-99);
                    AddFrogTurns(-99);
                    SetHealTurns(5, 10);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    GetComponentInChildren<Animator>().enabled = true;
                    break;
                case 5:
                    SetHealTurns(5, 20);
                    //useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 6:
                    AddHp(-50);
                    useBombAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 7:
                    SetHealTurns(8, 15);
                    //useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 8:
                    AddHp(999);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 9:
                    AddFireTurns(5);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 10:
                    AddFireTurns(-99);
                    SetHealTurns(5, 10);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 11:
                    battleManager.enemy.AddFrogTurns(3);
                    battleManager.hero.AddFrogTurns(3);
                    battleManager.enemy.drugEffect.SetTrigger("Show");
                    battleManager.hero.drugEffect.SetTrigger("Show");
                    battleManager.AllChange2Frog();
                    useFrogAudio.Play();
                    break;
                case 12:
                    AddPowerUpTurns(99);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
                case 13:
                    battleManager.enemy.AddHp((int)(-battleManager.enemy.hpMax * 0.8f));
                    battleManager.hero.AddHp((int)(-battleManager.hero.hpMax * 0.8f));
                    battleManager.enemy.drugEffect.SetTrigger("Show");
                    battleManager.hero.drugEffect.SetTrigger("Show");
                    useMedicineAudio.Play();
                    break;
                case 14:
                    int[] temp = { 0, 0, 0, 1, 0, 0 };
                    Bag.Instance.GetMaterial(temp);
                    useFrogAudio.Play();
                    //drugEffect.SetTrigger("Show");
                    break;
                default:
                    AddHp(-1);
                    useMedicineAudio.Play();
                    drugEffect.SetTrigger("Show");
                    break;
            }
            //battleManager.CheckSomeoneDead();
        }
    }
}
