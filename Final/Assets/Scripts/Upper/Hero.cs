using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : PersonBehavior {

    private PersonObject myPersonObjectScript;

    [SerializeField] AudioSource[] skillAudios;

    // Use this for initialization
    void Start()
    {
        myPersonObjectScript = GetComponent<PersonObject>();
        myPersonObjectScript.skills = new PersonObject.Skill[1];

        myPersonObjectScript.skills[0] = new PersonObject.Skill();
        myPersonObjectScript.skills[0].hp = -20;
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
        
    }

    public override void playMusic(int skillId)
    {
        skillAudios[Random.Range(0, 4)].Play();
    }
}
