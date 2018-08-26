using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {
    private static Bag instance = null;
    public static Bag Instance { get { return instance; } }
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
        BagMaterial[] bagMaterials = GetComponentsInChildren<BagMaterial>();
        for (int i = 0; i < 6; i++)
        {
            //Debug.Log(bagMaterials[i].name);
            bagMaterials[i].AddMaterialToBag(addList[i]);
        }
    }
}
