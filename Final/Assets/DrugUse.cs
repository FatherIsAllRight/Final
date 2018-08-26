using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugUse : MonoBehaviour {

    private static DrugUse instance = null;
    public static DrugUse Instance { get { return instance; } }
    [HideInInspector] public int holdDrugType;
    private bool hold;
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

    public void HoldDrug(int _drugType)
    {
        holdDrugType = _drugType;
        hold = true;
    }
}
