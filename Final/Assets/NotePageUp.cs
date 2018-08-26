using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePageUp : MonoBehaviour {

    private void OnMouseDown()
    {
        NoteManager.Instance.PageUp();
    }
}
