using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : PersonBehavior {

    private PersonObject myPersonObjectScript;
    private int materialDropTimes;

    // Use this for initialization
    void Start () {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[4];

        myPersonObjectScript.skills[0] = new PersonObject.Skill();
        myPersonObjectScript.skills[0].hp = -50;

        myPersonObjectScript.skills[1] = new PersonObject.Skill();
        myPersonObjectScript.skills[1].hp = -40;
        myPersonObjectScript.skills[1].fireTurns = 2;

        myPersonObjectScript.skills[2] = new PersonObject.Skill();
        myPersonObjectScript.skills[2].hp = -50;
        myPersonObjectScript.skills[2].stunTurns = 2;

        myPersonObjectScript.skills[3] = new PersonObject.Skill();
        myPersonObjectScript.skills[3].selfWaitTurns = 1;
        myPersonObjectScript.skills[3].hp = -400;

        materialDropTimes = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override int selectSkill()
    {
        return Random.Range(3, 4);
    }

    public override void dropMaterial()
    {
        if (materialDropTimes == 0 && myPersonObjectScript.hp <= 1000)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(30, 51);
            materialList[1] = Random.Range(3, 7);
            materialList[2] = 0;
            materialList[3] = Random.Range(0, 2);
            materialList[4] = 0;
            materialList[5] = Random.Range(3, 6);
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
        else if (materialDropTimes == 1 && myPersonObjectScript.hp <= 500)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(30, 51);
            materialList[1] = Random.Range(3, 7);
            materialList[2] = 0;
            materialList[3] = Random.Range(0, 2);
            materialList[4] = 0;
            materialList[5] = Random.Range(3, 6);
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
        else if (materialDropTimes == 2 && myPersonObjectScript.hp <= 0)
        {
            int[] materialList = new int[6];
            materialList[0] = 0;
            materialList[1] = 0;
            materialList[2] = 0;
            materialList[3] = 0;
            materialList[4] = Random.Range(0, 3);
            materialList[5] = 0;
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
    }

}
