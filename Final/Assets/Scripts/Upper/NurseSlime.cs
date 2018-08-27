using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSlime : PersonBehavior {

    private PersonObject myPersonObjectScript;
    private int materialDropTimes;

    private AudioSource skillAudio;

    private bool flag = false;

    // Use this for initialization
    void Start()
    {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[2];

        myPersonObjectScript.skills[0] = new PersonObject.Skill();
        myPersonObjectScript.skills[0].hp = -10;

        myPersonObjectScript.skills[1] = new PersonObject.Skill();
        myPersonObjectScript.skills[1].hp = -5;
        myPersonObjectScript.skills[1].selfHealTurns = 10;
        myPersonObjectScript.skills[1].selfHealRestore = 30;

        materialDropTimes = 0;

        skillAudio = GameObject.Find("Hit").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

    }

    public override int selectSkill()
    {
        if (flag)
            return 0;
        else
        {
            flag = true;
            return 1;
        } 
    }

    public override void dropMaterial()
    {
        if (materialDropTimes == 0 && myPersonObjectScript.hp <= 0)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(20, 31);
            materialList[1] = 0;
            materialList[2] = Random.Range(1, 4);
            materialList[3] = 0;
            materialList[4] = 0;
            materialList[5] = 5;
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
    }

    public override void playMusic(int skillId)
    {
        skillAudio.Play();
    }
}
