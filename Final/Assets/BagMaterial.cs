using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagMaterial : MonoBehaviour {

    [HideInInspector]public Sprite materialSprite;
    public int materialNum;
    public Text materialNumText;
    public int materialType;

	// Use this for initialization
	void Start () {
        materialSprite = GetComponent<SpriteRenderer>().sprite;
        if (materialNum == 0)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 0.4f;
            GetComponent<SpriteRenderer>().color = color;
            materialNumText.gameObject.SetActive(false);
        }
        else
        {
            materialNumText.gameObject.SetActive(true);
            materialNumText.text = materialNum.ToString();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddMaterialToBag(int add)
    {
        materialNum += add;
        if(!materialNumText.gameObject.activeSelf)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 1.0f;
            GetComponent<SpriteRenderer>().color = color;
            materialNumText.gameObject.SetActive(true);
        }
        materialNumText.text = materialNum.ToString();
    }

    private void OnMouseDown()
    {
        if(materialNum == 0 || PotManager.Instance.gridUsed == PotManager.Instance.gridList.Length)
        {
            return;
        }
        PotManager.Instance.AddMaterailToPot(materialSprite, materialType);
        materialNum--;
        materialNumText.text = materialNum.ToString();
        if(materialNum == 0)
        {
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 0.4f;
            GetComponent<SpriteRenderer>().color = color;
            materialNumText.gameObject.SetActive(false);
        }
        else{
            materialNumText.gameObject.SetActive(true);
            materialNumText.text = materialNum.ToString();
        }
    }
}
