using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePageDown : MonoBehaviour {

    private void OnMouseDown()
    {
        NoteManager.Instance.PageDown();
    }
}
