using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour {

    private PersonObject myPersonObjectScript;

    // Use this for initialization
    void Start()
    {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[1];
        myPersonObjectScript.skills[0] = new PersonObject.Skill(0, -20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
