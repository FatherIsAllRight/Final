using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalNextScene : MonoBehaviour {

    [SerializeField] SpriteRenderer Mask;
    [SerializeField] float MaskTime;
    [SerializeField] int NextScene;
    private int phrase;

    // Use this for initialization
    void Start () {
        phrase = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(phrase == 0)
        {
            Mask.color = new Color(Mask.color.r, Mask.color.g, Mask.color.b, Mask.color.a - 1 * Time.deltaTime / MaskTime);
            if(Mask.color.a < 0)
            {
                phrase = 1;
            }
        }
        else if(phrase == 2)
        {
            Mask.color = new Color(Mask.color.r, Mask.color.g, Mask.color.b, Mask.color.a + 1 * Time.deltaTime / MaskTime);
            if (Mask.color.a > 1)
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }

    void OnMouseDown()
    {
        if(phrase == 1)
        {
            phrase = 2;
        }
    }
}
