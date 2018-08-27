using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpperManager : MonoBehaviour {
    private static UpperManager instance = null;
    public static UpperManager Instance { get { return instance; } }
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
        currentRoom = 0;
        roomsType = new int[10] {-1, 0, -3, -99, -99, -99, -99, -99, -2, 3};
        int[] a = { -3, -2, 1, 2, 2 };
        int[] b = a.OrderBy(x => Guid.NewGuid()).ToArray();
        for(int i = 0; i < b.Length; i++)
        {
            roomsType[i + 3] = b[i];
        }

        for (int i = 0; i < rooms.Length; i++)
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

                switch (roomsType[currentRoom - 1])
                {
                    case -1:
                        break;
                    case -2:
                        roomIcons[currentRoom - 1].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[3];
                        break;
                    case -3:
                        roomIcons[currentRoom - 1].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[2];
                        break;
                    case 4:
                        roomIcons[currentRoom - 1].GetComponent<SpriteRenderer>().sprite = roomIconsSprite[4];
                        break;
                    default:
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

                if (currentRoom == 1)
                {
                    Mask.GetComponent<SpriteRenderer>().sortingOrder = 2;
                }
                if (currentRoom == roomsType.Length - 1)
                {
                    Mask.GetComponent<SpriteRenderer>().sortingOrder = 31;
                }
            }
        }
    }

    public void NextRoom()
    {
        currentRoom++;
        nextRoom = 1;
    }

    public bool DrugMakable()
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

    public bool DrugUseable()
    {
        if (BattleManager.GetComponent<BattleManager>().battleStart)
        {
            return true;
        }
        return false;
    }
}
