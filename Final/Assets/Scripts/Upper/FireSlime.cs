using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlime : PersonBehavior {

    private PersonObject myPersonObjectScript;
    private int materialDropTimes;

    private AudioSource skillAudio;

    // Use this for initialization
    void Start()
    {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[2];

        myPersonObjectScript.skills[0] = new PersonObject.Skill();
        myPersonObjectScript.skills[0].hp = -40;

        myPersonObjectScript.skills[1] = new PersonObject.Skill();
        myPersonObjectScript.skills[1].fireTurns = 3;

        materialDropTimes = 0;

        skillAudio = GameObject.Find("Hit").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

    }

    public override int selectSkill()
    {
        int temp = Random.Range(0, 100);
        if (temp < 80)
            return 0;
        else
            return 1;
    }

    public override void dropMaterial()
    {
        if (materialDropTimes == 0 && myPersonObjectScript.hp <= 200)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(6, 9);
            materialList[1] = 0;
            materialList[2] = 0;
            materialList[3] = 0;
            materialList[4] = 0;
            materialList[5] = Random.Range(3, 5);
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
        else if (materialDropTimes == 1 && myPersonObjectScript.hp <= 100)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(6, 9);
            materialList[1] = 0;
            materialList[2] = 0;
            materialList[3] = 0;
            materialList[4] = 0;
            materialList[5] = Random.Range(3, 5);
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
        else if (materialDropTimes == 2 && myPersonObjectScript.hp <= 0)
        {
            int[] materialList = new int[6];
            materialList[0] = 0;
            materialList[1] = 0;
            materialList[2] = Random.Range(3, 6);
            materialList[3] = 1;
            materialList[4] = 0;
            materialList[5] = 0;
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
    }

    public override void playMusic(int skillId)
    {
        skillAudio.Play();
    }
}
