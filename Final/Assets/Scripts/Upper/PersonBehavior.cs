using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract int selectSkill();
    public abstract void dropMaterial();
}
