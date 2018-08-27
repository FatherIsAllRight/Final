using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialToBag : MonoBehaviour {

    private Vector3 start = new Vector3(3.5f, 3, 0);
    private Vector3 end = new Vector3(6f, -1, 0);
    public float waitTime = 99f;

    // Use this for initialization
    void Start () {
        //this.transform.position = start;
        //this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 0);

    }
	
	// Update is called once per frame
	void Update () {
        waitTime -= Time.deltaTime;
        if(waitTime < 0)
        {
            //this.GetComponent<SpriteRenderer>().color = new Color(this.GetComponent<SpriteRenderer>().color.r, this.GetComponent<SpriteRenderer>().color.g, this.GetComponent<SpriteRenderer>().color.b, 1);
            //this.transform.Translate((end - start) / (0.3f / Time.deltaTime));
            GetComponent<Animator>().SetInteger("Fall", 1);
            if (this.transform.position.y < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
