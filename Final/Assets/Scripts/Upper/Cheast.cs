using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheast : MonoBehaviour {

    [SerializeField] GameObject nextRoomButton;
    private bool isOpen;

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
            Debug.Log("Get some Medicine");
            nextRoomButton.SetActive(true);
            isOpen = true;
        }
    }

    public void Init()
    {
        isOpen = false;
    }
}
