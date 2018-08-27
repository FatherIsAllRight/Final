using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour {
    [SerializeField] bool hpType; //false--enemy; true--hero
    //[HideInInspector] public bool hideHp;
    [SerializeField] SpriteMask hpMask;
    [SerializeField] PersonObject personObject;
    private Text hpText;
    private int lastHp;
	// Use this for initialization
	void Start () {
        lastHp = personObject.hp;
        GameObject canvas = GameObject.Find("Canvas");
        GameObject hpTextObj;
        if(hpType)
            hpTextObj = canvas.transform.Find("HeroHpNum").gameObject;
        else
            hpTextObj = canvas.transform.Find("EnemyHpNum").gameObject;
        hpTextObj.SetActive(true);
        hpText = hpTextObj.GetComponent<Text>();
        hpText.text = personObject.hp.ToString() + " / " + personObject.hpMax.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(lastHp == personObject.hp)
            return;
        //UpdateHp();
	}

    public void UpdateHp()
    {
        /*if(personObject.hp <= 0)
        {
            hpText.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }*/
        float deltaX = ((float)personObject.hp / personObject.hpMax - 1) * 2.56f;
        hpMask.transform.localPosition = new Vector3(deltaX, 0, 0);
        hpText.text = personObject.hp.ToString() + " / " + personObject.hpMax.ToString();
    }
}
