using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRecord : MonoBehaviour {
    private static NoteRecord instance = null;
    public static NoteRecord Instance { get { return instance; } }
    [HideInInspector] public bool[] notePageRecord;
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
        notePageRecord = new bool[14];
        notePageRecord[1] = true;
        DontDestroyOnLoad(this);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateNoteRecord(bool[] _noteUnlock)
    {
        for (int i = 0; i < 14; i++)
        {
            notePageRecord[i] = _noteUnlock[i];
        }
    }
}
