﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour {
    [HideInInspector] public int drugType;
    [SerializeField] Sprite[] drugList; //废药--0；青蛙--14  
	// Use this for initialization
	void Start () {
        drugType = -1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setDrug(int _drugType)
    {
        //drugType = _drugType;
        //TODO add animation trigger?
        GetComponent<Animator>().SetTrigger("Shake");
        switch (_drugType)
        {
            case 111:
                drugType = 1;
                break;
            case 116:
                drugType = 2;
                break;
            case 166:
                drugType = 3;
                break;
            case 666:
                drugType = 4;
                break;
            case 113:
                drugType = 5;
                break;
            case 223:
                drugType = 6;
                break;
            case 136:
                drugType = 7;
                break;
            case 366:
                drugType = 8;
                break;
            case 224:
                drugType = 9;
                break;
            case 146:
                drugType = 10;
                break;
            case 444:
                drugType = 11;
                break;
            case 555:
                drugType = 12;
                break;
            default:
                int a = drugType / 100;
                int b = (drugType % 100) / 10;
                int c = drugType % 10;
                if(a == 5 || b == 5 || c == 5)
                {
                    drugType = 13;
                    break;
                }
                else if(b == 4 && (a == 4 || c == 4))
                {
                    drugType = 14;

                    break;
                }
                drugType = 0;
                break;
        }
        if (drugType < 14 && drugType > 0){
            NoteManager.Instance.notePageUnlock[drugType] = true;
            NoteManager.Instance.Refresh();
        }
            
        GetComponent<SpriteRenderer>().sprite = drugList[drugType];
    }

    private void OnMouseDown()
    {
        
    }
}
