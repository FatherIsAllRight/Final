using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    private int enemyHpMax;
    private int enemyHpCurrent;
    private int heroHpMax;
    private int heroHpCurrent;
    [SerializeField] float turnMaxTime;
    private float turnTime;

    private bool moveTurn; //false--enemy;  true--hero
    private bool battleStart = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(battleStart)
        {
            turnTime += Time.deltaTime;
            if(turnTime >= turnMaxTime)
            {
                turnTime = 0;
                if(moveTurn)
                {
                    //hero move
                    enemyHpCurrent -= 5;
                }
                else{
                    //enemy move

                }
            }
        }
	}

    public void InitBattle(int _heroHp, int _enemyHp, bool _moveTurn)
    {
        enemyHpMax = _enemyHp;
        enemyHpCurrent = _enemyHp;
        heroHpMax = _heroHp;
        heroHpCurrent = _heroHp;
        moveTurn = _moveTurn;
        turnTime = 0;
        battleStart = true;
    }
}
