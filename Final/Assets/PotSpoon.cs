using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpoon : MonoBehaviour {
    private bool cook;
    private int drugType;
    [SerializeField] float cookLimitTime;
    private float cookCurrentTime;
    [SerializeField] Animator cookAni;
    private AnimatorStateInfo cookAniInfo;
    private bool shine;
    [SerializeField] Animator glowAni;
    // Use this for initialization
	void Start () {
        cook = false;
        shine = false;
        cookCurrentTime = 0;
        drugType = -1;
	}
	
	// Update is called once per frame
	void Update () {
        if(cook)
        {
            cookAniInfo = cookAni.GetCurrentAnimatorStateInfo(0);
            if(!shine && cookAniInfo.IsName("PotCookRotate") && cookAniInfo.normalizedTime > 0.7f)
            {
                shine = true;
                int l = ShelfManager.Instance.shelfBottleList.Length;
                for (int i = 0; i < l; i++)
                {
                    Drug tempDrug = ShelfManager.Instance.shelfBottleList[i].GetComponent<Drug>();

                    if (tempDrug.drugType == -1)
                    {
                        tempDrug.setDrug(drugType);
                        ShelfManager.Instance.bottleUsed++;
                        ShelfManager.Instance.shelfBottleList[i].GetComponent<Animator>().SetTrigger("Shake");
                        glowAni.transform.position = ShelfManager.Instance.shelfBottleList[i].transform.position;
                        glowAni.SetTrigger("Glow");
                        return;
                    }
                }
            }
            if(shine && cookAniInfo.IsName("PotCookRotate") && cookAniInfo.normalizedTime >= 0.99f)
            {
                cook = false;
                PotManager.Instance.InitPot();
                GetComponent<PolygonCollider2D>().enabled = true;
                shine = false;
            }

        }
	}

    private void OnMouseDown()
    {
        if(PotManager.Instance.gridUsed == PotManager.Instance.gridList.Length && ShelfManager.Instance. bottleUsed < ShelfManager.Instance.shelfBottleList.Length)
        {
            List<int> materialList = new List<int>();
            int l = PotManager.Instance.gridList.Length;
            for (int i = 0; i < l; i++)
            {
                materialList.Add(PotManager.Instance.gridMaterialType[i]);
                PotManager.Instance.gridList[i].GetComponent<CircleCollider2D>().enabled = false;
            }
            materialList.Sort();
            drugType = materialList[0] * 100 + materialList[1] * 10 + materialList[2];
            cook = true;
            GetComponent<PolygonCollider2D>().enabled = false;
            cookAni.SetTrigger("Cook");
        }
    }
}
