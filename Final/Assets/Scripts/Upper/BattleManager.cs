﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

    [SerializeField] float turnMaxTime;
    [SerializeField] float turnAniTime;
    private float turnTime;
    private bool aniTrigger = false;


    private bool moveTurn; //false--enemy;  true--hero
    public bool battleStart { get; private set; }

    [HideInInspector]public PersonObject enemy;
    [SerializeField]public PersonObject hero;

    [SerializeField] GameObject nextRoomButton;

    [SerializeField] GameObject[] Enemy;
    //[SerializeField] GameObject heroHpText;
    [SerializeField] GameObject enemyHpText;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(battleStart)
        {
            turnTime += Time.deltaTime;
            if(!aniTrigger && turnTime >= turnAniTime)
            {
                aniTrigger = true;
                if(moveTurn)
                {
                    if(hero.stunTurns <= 0)
                        hero.GetComponentInChildren<Animator>().SetTrigger("Attack");
                    if (enemy.waitTurns > 0 || hero.stunTurns > 0)
                        return;
                    enemy.GetComponentInChildren<Animator>().SetTrigger("Hurt");
                }
                else
                {
                    string triggerName = enemy.lastSkillId.ToString();
                    //Debug.Log(triggerName);
                    enemy.GetComponentInChildren<Animator>().SetTrigger(triggerName);
                    Debug.Log("turn   " + enemy.waitTurns);
                    Debug.Log("skillId  " + enemy.lastSkillId);
                    if (enemy.lastSkillId == 3 && enemy.waitTurns != 1)
                        return;
                    hero.GetComponentInChildren<Animator>().SetTrigger("Hurt");


                }
            }
            if(turnTime >= turnMaxTime)
            {
                turnTime = 0;
                aniTrigger = false;
                if (moveTurn)
                {
                    //Debug.Log("hero");
                    hero.UseSkill(enemy);
                }
                else {
                    //Debug.Log("enemy");
                    enemy.UseSkill(hero);
                }
                moveTurn = !moveTurn;

                CheckSomeoneDead();
            }
        }
	}

    public void InitBattle(int enemy, bool moveTurn)
    {
        Instantiate(Enemy[enemy]);
        this.enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PersonObject>();
        this.moveTurn = moveTurn;
        this.turnTime = 0;
        this.battleStart = true;
    }

    public void CheckSomeoneDead()
    {
        if (hero.isDead())
        {
            // game over
            SceneManager.LoadScene(2);
            return;
        }

        if (enemy.isDead())
        {
            battleStart = false;
            //drug use
            DrugUse.Instance.ClearHand();
            nextRoomButton.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            enemyHpText.SetActive(false);
            hero.clearBuff();
        }
    }
}
