using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : PersonBehavior {

    private PersonObject myPersonObjectScript;
    private int materialDropTimes;

    [SerializeField] AudioClip[] skillAudios;

    // Use this for initialization
    void Start () {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[4];

        myPersonObjectScript.skills[0] = new PersonObject.Skill();
        myPersonObjectScript.skills[0].hp = -50;

        myPersonObjectScript.skills[1] = new PersonObject.Skill();
        myPersonObjectScript.skills[1].hp = -10;
        myPersonObjectScript.skills[1].fireTurns = 5;

        myPersonObjectScript.skills[2] = new PersonObject.Skill();
        myPersonObjectScript.skills[2].hp = -50;
        myPersonObjectScript.skills[2].stunTurns = 5;

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
        int temp = Random.Range(0, 100);
        if (temp < 65)
            return 0;
        else if (temp < 85)
            return 1;
        else if (temp < 95)
            return 2;
        else
            return 3;
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
            materialList[4] = 2;
            materialList[5] = 0;
            Bag.Instance.GetMaterial(materialList);
            materialDropTimes++;
        }
    }

    public override void playMusic(int skillId)
    {
        this.gameObject.GetComponent<AudioSource>().clip = skillAudios[skillId];
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
