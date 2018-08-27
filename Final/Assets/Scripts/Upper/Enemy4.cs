using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour {

    private PersonObject myPersonObjectScript;

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
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
