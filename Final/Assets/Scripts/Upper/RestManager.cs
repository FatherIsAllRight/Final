using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestManager : MonoBehaviour {

    [SerializeField] int restore;
    [SerializeField] GameObject nextRoomButton;
    [SerializeField] PersonObject hero;

    [SerializeField] AudioSource restAudio;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init()
    {
        hero.AddHp(restore);
        nextRoomButton.SetActive(true);
        restAudio.Play();
    }
}
