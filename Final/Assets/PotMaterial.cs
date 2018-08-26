using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotMaterial : MonoBehaviour {

    [SerializeField] int gridIndex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        int index = PotManager.Instance.gridMaterialType[gridIndex - 1] - 1;
        PotManager.Instance.gridUsed--;
        PotManager.Instance.bagMaterialList[index].AddMaterialToBag(1);
        PotManager.Instance.gridMaterialType[gridIndex - 1] = -1;
        GetComponent<SpriteRenderer>().sprite = null;
    }
}