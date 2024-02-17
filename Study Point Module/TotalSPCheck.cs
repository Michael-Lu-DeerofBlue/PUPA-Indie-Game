using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalSPCheck : MonoBehaviour
{
    public TextMeshPro TSP;
    public GameObject Load;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Check()
    {
        int SPThreshold = 600;
        if (LeftEnergy.RoundNum == 2)
        {
            SPThreshold = 100;
        }
        else if (LeftEnergy.RoundNum == 3)
        {
            SPThreshold = 190;
        }
        else if (LeftEnergy.RoundNum == 4)
        {
            SPThreshold = 280;
        }
        else if (LeftEnergy.RoundNum == 5)
        {
            SPThreshold = 370;
        }
        else if (LeftEnergy.RoundNum == 6)
        {
            SPThreshold = 460;
        }
        else if (LeftEnergy.RoundNum == 7)
        {
            SPThreshold = 550;
        }

        if (LoadAllCardCode.SPSum > SPThreshold)
        {
            if (LeftEnergy.RoundNum == 2)
            {
                LoadAllCardCode.TTSP2 = true;
            }
            else if (LeftEnergy.RoundNum == 3)
            {
                LoadAllCardCode.TTSP3 = true;
            }
            else if (LeftEnergy.RoundNum == 4)
            {
                LoadAllCardCode.TTSP4 = true;
            }
            else if (LeftEnergy.RoundNum == 5)
            {
                LoadAllCardCode.TTSP5 = true;
            }
            else if (LeftEnergy.RoundNum == 6)
            {
                LoadAllCardCode.TTSP6 = true;
            }
            else if (LeftEnergy.RoundNum == 7)
            {
                LoadAllCardCode.TTSP7 = true;
            }
        }
        string TotalBuffText = "";
        if (LoadAllCardCode.TTSP2 == true)
        {
            TotalBuffText = TotalBuffText + "所有考试专注值上限再增加20;";
        }
        if (LoadAllCardCode.TTSP3 == true)
        {
            TotalBuffText = TotalBuffText + "所有考试时间上限再增加20;";
        }
        if (LoadAllCardCode.TTSP4 == true)
        {
            TotalBuffText = TotalBuffText + "所有整理思路时间消耗再减去5;";
        }
        if (LoadAllCardCode.TTSP5 == true)
        {
            TotalBuffText = TotalBuffText + "所有学科复习精力再减少5;";
        }
        if (LoadAllCardCode.TTSP6 == true)
        {
            TotalBuffText = TotalBuffText + "所有考试weak伤害倍数再提升10%;";
        }
        if (LoadAllCardCode.TTSP7 == true)
        {
            TotalBuffText = TotalBuffText + "所有考试专注值扣费再减少10;";
        }
        TSP.text = TotalBuffText;
        Load.GetComponent<LoadAllCardCode>().SaveData();
    }
}
