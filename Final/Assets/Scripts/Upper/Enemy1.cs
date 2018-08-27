using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : PersonBehavior {

    private PersonObject myPersonObjectScript;
    private int materialDropTimes;

    // Use this for initialization
    void Start()
    {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[1];

        myPersonObjectScript.skills[0] = new PersonObject.Skill();
        myPersonObjectScript.skills[0].hp = -20;

        materialDropTimes = 0;
    }

    // Update is called once per frame
    void Update () {

    }

    public override int selectSkill()
    {
        return 0;
    }

    public override void dropMaterial()
    {
        if (materialDropTimes == 0 && myPersonObjectScript.hp <= 100)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(3, 5);
            materialList[1] = Random.Range(0, 3);
            materialList[2] = 0;
            materialList[3] = 0;
            materialList[4] = 0;
            materialList[5] = Random.Range(1, 3);
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
        else if (materialDropTimes == 1 && myPersonObjectScript.hp <= 50)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(3, 5);
            materialList[1] = Random.Range(0, 3);
            materialList[2] = 0;
            materialList[3] = 0;
            materialList[4] = 0;
            materialList[5] = Random.Range(1, 3);
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
        else if (materialDropTimes == 2 && myPersonObjectScript.hp <= 0)
        {
            int[] materialList = new int[6];
            materialList[0] = 0;
            materialList[1] = 0;
            materialList[2] = Random.Range(3, 6);
            materialList[3] = 0;
            materialList[4] = 0;
            materialList[5] = 0;
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
    }
}
