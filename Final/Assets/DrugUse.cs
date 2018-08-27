using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugUse : MonoBehaviour {

    private static DrugUse instance = null;
    public static DrugUse Instance { get { return instance; } }
    [HideInInspector] public int holdDrugType;
    //[HideInInspector] public bool hold;
    [HideInInspector] public Drug drug;
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
    public void UseThisDrug()
    {
        if (drug == null)
            return;
        drug.GetComponent<SpriteRenderer>().sprite = null;
        Debug.Log("Use drug type : " + drug.drugType.ToString());
        drug.drugType = -1;
        drug.hand.SetActive(false);
        ShelfManager.Instance.shelfUsed--;
    }

    public void ClearHand()
    {
        if (drug == null)
            return;
        drug.hand.SetActive(false);
        drug = null;
    }
    /*
    public void HoldDrug(int _drugType)
    {
        holdDrugType = _drugType;
        //hold = true;
    }
    */
}
