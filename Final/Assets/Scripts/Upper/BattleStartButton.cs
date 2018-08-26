using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartButton : MonoBehaviour {

    private BattleManager battleManager;

    // Use this for initialization
    void Start()
    {
        battleManager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnMouseDown()
    {
        //battleManager.battleStart = true;
        gameObject.SetActive(false);
    }
}
