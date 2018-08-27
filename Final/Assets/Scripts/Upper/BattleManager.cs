using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

    [SerializeField] float turnMaxTime;
    private float turnTime;

    private bool moveTurn; //false--enemy;  true--hero
    public bool battleStart { get; private set; }

    private PersonObject enemy;
    [SerializeField] PersonObject hero;

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
            if(turnTime >= turnMaxTime)
            {
                turnTime = 0;
                if (moveTurn)
                {
                    Debug.Log("hero");
                    hero.UseSkill(enemy);
                }
                else {
                    Debug.Log("enemy");
                    enemy.UseSkill(hero);
                }
                moveTurn = !moveTurn;

                if (hero.isDead())
                {
                    // game over
                    SceneManager.LoadScene(2);
                    return;
                }

                if (enemy.isDead())
                {
                    Debug.Log(1);
                    battleStart = false;
                    //drug use
                    DrugUse.Instance.ClearHand();
                    nextRoomButton.SetActive(true);
                    Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                    enemyHpText.SetActive(false);
                }
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
}
