using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SPBuffJudgement : MonoBehaviour
{
    public int Threshold;
    public GameObject Load;
    public int TestInt;
    public float TotalSP;
    // Start is called before the first frame update
    public void Judge()
    {
        if (LeftEnergy.RoundNum == 2)
        {
            Threshold = 30;
        }
        else if (LeftEnergy.RoundNum == 3 || LeftEnergy.RoundNum == 4)
        {
            Threshold = 50;
        }
        else if (LeftEnergy.RoundNum == 5 || LeftEnergy.RoundNum == 6)
        {
            Threshold = 70;
        }
        else if (LeftEnergy.RoundNum == 7 || LeftEnergy.RoundNum == 8)
        {
            Threshold = 90;
        }
        if (LoadAllCardCode.ChnSPTR1 == false)
        {
            if (LoadAllCardCode.ChnSP1 > Threshold)
            {
                LoadAllCardCode.ChnSPBuffVar1++;
                LoadAllCardCode.ChnSPTR1 = true;
            }
        }
        if (LoadAllCardCode.ChemSPTR1 == false)
        {
            if (LoadAllCardCode.ChemSP1 > Threshold)
            {
                LoadAllCardCode.ChemSPBuffVar1++;
                LoadAllCardCode.ChemSPTR1 = true;
            }
        }
        if (LoadAllCardCode.BioSPTR1 == false)
        {
            if (LoadAllCardCode.BioSP1 > Threshold)
            {
                LoadAllCardCode.BioSPBuffVar1++;
                LoadAllCardCode.BioSPTR1 = true;
            }
        }
        if (LoadAllCardCode.GerSPTR1 == false)
        {
            if (LoadAllCardCode.GerSP1 > Threshold)
            {
                LoadAllCardCode.GerSPBuffVar1++;
                LoadAllCardCode.GerSPTR1 = true;
            }
        }
        if (LoadAllCardCode.PhysSPTR1 == false)
        {
            if (LoadAllCardCode.PhysSP1 > Threshold)
            {
                LoadAllCardCode.PhysSPBuffVar1++;
                LoadAllCardCode.PhysSPTR1 = true;
            }
        }
        if (LoadAllCardCode.MathSPTR1 == false)
        {
            if (LoadAllCardCode.MathSP1 > Threshold)
            {
                LoadAllCardCode.MathSPBuffVar1++;
                LoadAllCardCode.MathSPTR1 = true;
            }
        }
        if (LoadAllCardCode.EBSPTR1 == false)
        {
            if (LoadAllCardCode.EBSP1 > Threshold)
            {
                LoadAllCardCode.EBSPBuffVar1++;
                LoadAllCardCode.EBSPTR1 = true;
            }
        }
        if (LoadAllCardCode.EconSPTR1 == false)
        {
            if (LoadAllCardCode.EconSP1 > Threshold)
            {
                LoadAllCardCode.EconSPBuffVar1++;
                LoadAllCardCode.EconSPTR1 = true;
            }
        }
        TotalSP = LoadAllCardCode.SPSum - 20;
        if (TotalSP >= 600)
        {
            Debug.Log("Here");
            SteamUserStats.SetAchievement("IB_LEARNER");
            SteamUserStats.StoreStats();
        }
        TestInt = LoadAllCardCode.ChnSPBuffVar1;
        Load.GetComponent<LoadAllCardCode>().SaveData();
    }

}
