using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour {

    private PersonObject myPersonObjectScript;

    // Use this for initialization
    void Start () {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[4];
        myPersonObjectScript.skills[0] = new PersonObject.Skill(0, -50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        myPersonObjectScript.skills[1] = new PersonObject.Skill(0, -40, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        myPersonObjectScript.skills[2] = new PersonObject.Skill(0, -50, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        myPersonObjectScript.skills[3] = new PersonObject.Skill(1, -400, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
