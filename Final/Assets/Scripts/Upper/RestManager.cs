using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestManager : MonoBehaviour {

    [SerializeField] int restore;
    [SerializeField] GameObject nextRoomButton;
    [SerializeField] PersonObject hero;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init()
    {
        hero.Add(restore, 0, 0, 0, 0, 0, 0);
        nextRoomButton.SetActive(true);
    }
}
