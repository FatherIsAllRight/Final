using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteManager : MonoBehaviour {
    public Sprite[] notePageList;
    [HideInInspector]public bool[] notePageUnlock;
    private int pageNum;
    private SpriteRenderer noteSprite;
    [SerializeField] Text pageNumText;
    [SerializeField] AudioSource noteAudio;

    private static NoteManager instance = null;
    public static NoteManager Instance { get { return instance; } }

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
        pageNum = 1;
        notePageUnlock = new bool[notePageList.Length];
        for (int i = 0; i < notePageList.Length; i++)
            notePageUnlock[i] = NoteRecord.Instance.notePageRecord[i];
        noteSprite = GetComponent<SpriteRenderer>();
        noteSprite.sprite = notePageList[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Refresh(int _pageNum)
    {
        pageNum = _pageNum;
        if (notePageUnlock[pageNum])
        {
            noteSprite.sprite = notePageList[pageNum];
        }
        else
        {
            noteSprite.sprite = notePageList[0];
        }
        pageNumText.text = pageNum.ToString() + " / " + (notePageList.Length - 1).ToString();
        noteAudio.Play();
    }

    public void PageUp()
    {
        if (pageNum < 2)
            return;
        pageNum--;
        if(notePageUnlock[pageNum])
        {
            noteSprite.sprite = notePageList[pageNum];
        }
        else
        {
            noteSprite.sprite = notePageList[0];
        }
        pageNumText.text = pageNum.ToString() + " / " + (notePageList.Length - 1).ToString();
        noteAudio.Play();
    }

    public void PageDown()
    {
        if(pageNum > notePageList.Length - 2)
            return;
        pageNum++;
        if (notePageUnlock[pageNum])
        {
            noteSprite.sprite = notePageList[pageNum];
        }
        else
        {
            noteSprite.sprite = notePageList[0];
        }
        pageNumText.text = pageNum.ToString() + " / " + (notePageList.Length - 1).ToString();
        noteAudio.Play();
    }
}
