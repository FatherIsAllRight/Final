﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpperManager : MonoBehaviour {

    [SerializeField] GameObject BattleManager;
    [SerializeField] GameObject TreasureManager;
    [SerializeField] GameObject RestManager;

    [SerializeField] GameObject Mask;
    private int nextRoom;
    [SerializeField] float nextRoomTime;

    [SerializeField] GameObject[] rooms;
    [SerializeField] GameObject[] roomIcons;
    [SerializeField] GameObject roomPointer;
    [SerializeField] Sprite[] roomsSprite;
    [SerializeField] Sprite[] roomIconsSprite;
    private int currentRoom;
    private int[] roomsType; // -1 start; >= 0 monster; -2 rest; -3 treasure

    // Use this for initialization
    void Start () {
        currentRoom = 0;
        roomsType = new int[10] {-1, 0, -3, 0, -2, 0, -3, 0, -2, 1};
        for(int i = 0; i < rooms.Length; i++)
        {
            rooms[i].GetComponent<SpriteRenderer>().sprite = roomsSprite[0];
            roomIcons[i].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[0];
        }
        roomPointer.transform.localPosition = new Vector3(rooms[0].transform.localPosition.x, rooms[0].transform.localPosition.y + 10, rooms[0].transform.localPosition.z);
        rooms[0].GetComponent<SpriteRenderer>().sprite = roomsSprite[1];
        roomIcons[0].GetComponent<SpriteRenderer>().sprite = null;
        NextRoom();
    }
	
	// Update is called once per frame
	void Update () {
		if(nextRoom == 1)
        {
            Mask.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Mask.GetComponent<SpriteRenderer>().color.a + 1 * Time.deltaTime / nextRoomTime);
            if(Mask.GetComponent<SpriteRenderer>().color.a > 1)
            {
                if (currentRoom >= roomsType.Length)
                {
                    SceneManager.LoadScene(3);
                    return;
                }

                BattleManager.SetActive(false);
                RestManager.SetActive(false);
                TreasureManager.SetActive(false);
                switch (roomsType[currentRoom]) 
                {
                    case -2:
                        RestManager.GetComponent<RestManager>().Init();
                        RestManager.SetActive(true);
                        break;
                    case -3:
                        TreasureManager.GetComponent<TreasureManager>().Init();
                        TreasureManager.SetActive(true);
                        break;
                    default:
                        BattleManager.GetComponent<BattleManager>().InitBattle(roomsType[currentRoom], true);
                        BattleManager.SetActive(true);
                        break;
                }

                nextRoom = 2;

                switch(roomsType[currentRoom - 1])
                {
                    case -1:
                        break;
                    case 0:
                    case 1:
                        roomIcons[currentRoom - 1].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[1];
                        break;
                    case -2:
                        roomIcons[currentRoom - 1].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[1];
                        break;
                    case -3:
                        roomIcons[currentRoom - 1].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[1];
                        break;
                }
            }
        }
        else if(nextRoom == 2)
        {
            Mask.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, Mask.GetComponent<SpriteRenderer>().color.a - 1 * Time.deltaTime / nextRoomTime);
            roomPointer.transform.localPosition = new Vector3(roomPointer.transform.localPosition.x + 80 * Time.deltaTime / nextRoomTime, roomPointer.transform.localPosition.y, roomPointer.transform.localPosition.z);
            if (Mask.GetComponent<SpriteRenderer>().color.a < 0)
            {
                roomPointer.transform.localPosition = new Vector3(rooms[currentRoom].transform.localPosition.x, rooms[currentRoom].transform.localPosition.y + 10, rooms[currentRoom].transform.localPosition.z);
                rooms[currentRoom].GetComponent<SpriteRenderer>().sprite = roomsSprite[1];
                roomIcons[currentRoom].GetComponent<SpriteRenderer>().sprite = null;
                nextRoom = 0;
            }
        }
    }

    public void NextRoom()
    {
        currentRoom++;
        nextRoom = 1;
    }

    public bool medicineMakable()
    {
        if(BattleManager.GetComponent<BattleManager>().battleStart)
        {
            return true;
        }

        if (RestManager.activeInHierarchy)
        {
            return true;
        }

        return false;
    }
}