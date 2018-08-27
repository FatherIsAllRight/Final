using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {
    private static Bag instance = null;
    public static Bag Instance { get { return instance; } }

    [SerializeField] GameObject material;
    [SerializeField] Sprite[] sprites;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetMaterial(int[] addList)
    {
        //int addCount = 0;
        BagMaterial[] bagMaterials = GetComponentsInChildren<BagMaterial>();
        /*
        for (int i = 0; i < 6; i++)
        {
            //Debug.Log(bagMaterials[i].name);

            bagMaterials[i].AddMaterialToBag(addList[i]);
            if (addList[i] > 0)
                addCount += addList[i];
        }
        */

        int addI = 0;
        for (int i = 0; i < 6; i++)
        {
            if (addList[i] > 0){
                GameObject oneMaterial = Instantiate(material);
                oneMaterial.GetComponent<SpriteRenderer>().sprite = sprites[i];
                //material.GetComponent<MaterialToBag>().waitTime = 0.5f - 0.5f / addCount * addI;
                oneMaterial.GetComponent<MaterialToBag>().waitTime = 0.1f + 0.2f * addI;
                //Debug.Log("Fall Num " + addI + " ::  "+material.GetComponent<MaterialToBag>().waitTime);
                bagMaterials[i].AddMaterialToBag(addList[i]);
                addI++;
            }
        }
    }
}
