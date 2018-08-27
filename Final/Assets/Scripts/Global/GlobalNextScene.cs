using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalNextScene : MonoBehaviour {

    [SerializeField] AudioSource Bgm;
    [SerializeField] SpriteRenderer Mask;
    [SerializeField] float MaskTime;
    [SerializeField] int NextScene;
    private int phrase;
    [SerializeField] Sprite guide;

    // Use this for initialization
    void Start () {
        phrase = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(phrase == 0)
        {
            Bgm.volume += 1.0f * Time.deltaTime / MaskTime;
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
                if(guide == null)
                    SceneManager.LoadScene(NextScene);
                phrase = 3;
                GetComponent<SpriteRenderer>().sprite = guide;
            }
        }
        else if(phrase == 3)
        {
            Mask.color = new Color(Mask.color.r, Mask.color.g, Mask.color.b, Mask.color.a - 1 * Time.deltaTime / MaskTime);
            if (Mask.color.a < 0)
            {
                phrase = 4;
            }
        }
        else if(phrase == 5)
        {
            Bgm.volume -= 1.1f * Time.deltaTime / MaskTime;
            Mask.color = new Color(Mask.color.r, Mask.color.g, Mask.color.b, Mask.color.a + 1 * Time.deltaTime / MaskTime);
            if (Mask.color.a > 1)
            {
                SceneManager.LoadScene(NextScene);
            }
        }
    }

    void OnMouseDown()
    {
        if(phrase == 1 || phrase == 4)
        {
            phrase++;
        }
    }
}
