using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour {
    private static ShelfManager instance = null;
    public static ShelfManager Instance { get { return instance; } }
    public GameObject[] shelfBottleList;
    [HideInInspector] public int bottleUsed;
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
        bottleUsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
