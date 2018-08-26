using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug : MonoBehaviour {
    [HideInInspector] public int drugType;
    [SerializeField] Sprite[] drugList; //废药--0；青蛙--14  
	// Use this for initialization
	void Start () {
        drugType = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setDrug(int _drugType)
    {
        drugType = _drugType;
        //TODO add animation trigger?
        GetComponent<Animator>().SetTrigger("Shake");
        int index = 0;
        switch (drugType)
        {
            case 111:
                index = 1;
                break;
            case 116:
                index = 2;
                break;
            case 166:
                index = 3;
                break;
            case 666:
                index = 4;
                break;
            case 113:
                index = 5;
                break;
            case 223:
                index = 6;
                break;
            case 136:
                index = 7;
                break;
            case 366:
                index = 8;
                break;
            case 224:
                index = 9;
                break;
            case 146:
                index = 10;
                break;
            case 444:
                index = 11;
                break;
            case 555:
                index = 12;
                break;
            default:
                int a = drugType / 100;
                int b = (drugType % 100) / 10;
                int c = drugType % 10;
                if(a == 5 || b == 5 || c == 5)
                {
                    index = 13;
                    break;
                }
                else if(b == 4 && (a == 4 || c == 4))
                {
                    index = 14;

                    break;
                }
                index = 0;
                break;
        }
        if (index < 14 && index > 0){
            NoteManager.Instance.notePageUnlock[index] = true;
            NoteManager.Instance.Refresh();
        }
            
        GetComponent<SpriteRenderer>().sprite = drugList[index];
    }
}
