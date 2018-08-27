using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotManager : MonoBehaviour {
    private static PotManager instance = null;
    public static PotManager Instance { get { return instance; } }
    [SerializeField]public GameObject[] gridList;
    [HideInInspector]public int[] gridMaterialType;
    public BagMaterial[] bagMaterialList;
    [HideInInspector] public int gridUsed = 0;

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
        gridMaterialType = new int[gridList.Length];
        InitPot();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddMaterailToPot(Sprite materialSp, int materialType)
    {
        for (int i = 0; i < gridList.Length; i++)
        {
            if(gridList[i].GetComponent<SpriteRenderer>().sprite == null)
            {
                gridUsed++;
                gridMaterialType[i] = materialType;
                gridList[i].GetComponent<SpriteRenderer>().sprite = materialSp;
                gridList[i].GetComponent<CircleCollider2D>().enabled = true;
                return;
            }
        }
    }

    public void InitPot()
    {
        gridUsed = 0;
        for (int i = 0; i < gridList.Length; i++)
        {
            gridList[i].GetComponent<SpriteRenderer>().sprite = null;
            gridList[i].GetComponent<CircleCollider2D>().enabled = false;
            gridMaterialType[i] = -1;
        }
    }
}