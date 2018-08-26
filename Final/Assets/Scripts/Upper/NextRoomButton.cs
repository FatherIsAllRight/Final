using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoomButton : MonoBehaviour {

    [SerializeField] GameObject UpperManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        UpperManager.GetComponent<UpperManager>().NextRoom();
        gameObject.SetActive(false);
    }
}
