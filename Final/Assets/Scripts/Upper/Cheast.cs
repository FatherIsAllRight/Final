using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheast : MonoBehaviour {

    [SerializeField] GameObject nextRoomButton;
    private bool isOpen;
    [SerializeField] Sprite cheastOpened;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if(!isOpen)
        {
            int[] materialList = new int[6];
            materialList[0] = Random.Range(12, 16);
            materialList[1] = Random.Range(3, 6);
            materialList[2] = 0;
            materialList[3] = Random.Range(3, 7);
            materialList[4] = 0;
            materialList[5] = Random.Range(4, 7);
            Bag.Instance.GetMaterial(materialList);
            nextRoomButton.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = cheastOpened;
            isOpen = true;
        }
    }

    public void Init()
    {
        isOpen = false;
    }
}
