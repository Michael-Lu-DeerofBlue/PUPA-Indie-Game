using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class IconActive : MonoBehaviour
{
    public GameObject Subject;
    public TextMeshPro LabelName;
    public TextMeshPro IconName;
    public string Message;
    public TextMeshPro Buff;
    public GameObject RedDot;
    public Flowchart flowchart;
    private TextMeshPro LableInList;
    public TextMeshPro List1;
    public TextMeshPro List2;
    public TextMeshPro List3;
    public TextMeshPro List4;
    public TextMeshPro List5;
    public TextMeshPro List6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Check()
    {
        string R5 = flowchart.GetStringVariable("Row5");
        string R6 = flowchart.GetStringVariable("Row6");
        int CheckSP = 0;
        string BuffText = "";

        if (IconName.text == "中文")
        {
            CheckSP = LoadAllCardCode.ChnSP1;
            LableInList = List1;
            int Value = 0;
            if (LoadAllCardCode.ChnSPTR1 == true)
            {
                Value = 100 + LoadAllCardCode.ChnSPBuffVar1 * 5;
                BuffText = "所有考试时专注值上限增加为" + Value.ToString();
            }
        }
        else if (IconName.text == "数学")
        {
            CheckSP = LoadAllCardCode.MathSP1;
            LableInList = List2;
            int Value = 0;
            if (LoadAllCardCode.MathSPTR1 == true)
            {
                Value = LoadAllCardCode.MathSPBuffVar1 * 5;
                BuffText = "所有考试时间增加" + Value.ToString();
            }
        }
        else if (IconName.text == "经济")
        {
            CheckSP = LoadAllCardCode.EconSP1;
            LableInList = List4;
            int Value = 0;
            if (LoadAllCardCode.EconSPTR1 == true)
            {
                Value = LoadAllCardCode.EconSPBuffVar1 * 3;
                BuffText = "复习精力减少" + Value.ToString();
            }
        }
        else if (IconName.text == "EB")
        {
            CheckSP = LoadAllCardCode.EBSP1;
            LableInList = List3;
            int Value = 0;
            if (LoadAllCardCode.EBSPTR1 == true)
            {
                Value = LoadAllCardCode.EBSPBuffVar1 * 1;
                BuffText = "整理思路时间减少" + Value.ToString();
            }
        }
        else if (IconName.text == "物理")
        {
            CheckSP = LoadAllCardCode.PhysSP1;
            if (R5 == "Physics")
            {
                int Value = 0;
                LableInList = List5;
                if (LoadAllCardCode.PhysSPTR1 == true)
                {
                    Value = LoadAllCardCode.PhysSPBuffVar1 * 10;
                    BuffText = BuffText = "所有考试weak伤害倍数提升" + Value.ToString()+"%";
                }
            }
            else if (R6 == "Physics")
            {
                int Value = 0;
                LableInList = List6;
                if (LoadAllCardCode.PhysSPTR1 == true)
                {
                    Value = LoadAllCardCode.PhysSPBuffVar1 * 10;
                    BuffText = "所有考试专注值扣费减少" + Value.ToString() + "%";
                }
              
            }
        }
        else if (IconName.text == "化学")
        {
            CheckSP = LoadAllCardCode.ChemSP1;
            if (R5 == "Chem")
            {
                int Value = 0;
                LableInList = List5;
                if (LoadAllCardCode.ChemSPTR1 == true)
                {
                    Value = LoadAllCardCode.ChemSPBuffVar1 * 10;
                    BuffText = BuffText = "所有考试weak伤害倍数提升" + Value.ToString() + "%";
                }
            }
            else if (R6 == "Chem")
            {
                int Value = 0;
                LableInList = List6;
                if (LoadAllCardCode.ChemSPTR1 == true)
                {
                    Value = LoadAllCardCode.ChemSPBuffVar1 * 10;
                    BuffText = "所有考试专注值扣费减少" + Value.ToString() + "%";
                }
            }
        }
        else if (IconName.text == "生物")
        {
            CheckSP = LoadAllCardCode.BioSP1;
            if (R5 == "Bio")
            {
                int Value = 0;
                if (LoadAllCardCode.BioSPTR1 == true)
                {
                    Value = LoadAllCardCode.BioSPBuffVar1 * 10;
                    BuffText = BuffText = "所有考试weak伤害倍数提升" + Value.ToString() + "%";
                }
            }
            else if (R6 == "Bio")
            {
                int Value = 0;
                LableInList = List6;
                if (LoadAllCardCode.BioSPTR1 == true)
                {
                    Value = LoadAllCardCode.BioSPBuffVar1 * 10;
                    BuffText = "所有考试专注值扣费减少" + Value.ToString() + "%";
                }
            }
        }
        else if (IconName.text == "德语")
        {
            CheckSP = LoadAllCardCode.GerSP1;
            int Value = 0;
            LableInList = List6;
            if (LoadAllCardCode.GerSPTR1 == true)
            {
                Value = LoadAllCardCode.GerSPBuffVar1 * 10;
                BuffText = "所有考试专注值扣费减少" + Value.ToString() + "%";
            }
        }
        int Threshold = 100;
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
        if (CheckSP > Threshold)
        {
            RedDot.SetActive(true);
            Buff.text = BuffText;
            LableInList.text = BuffText;
        }
    }

    private void OnMouseDown()
    {
        Subject.SetActive(true);
        if (IconName.text == "物理")
        {
            Message = "Physics";
        }
        else if (IconName.text == "化学")
        {
            Message = "Chem";
        }
        else if (IconName.text == "生物")
        {
            Message = "Bio";
        }
        else if (IconName.text == "德语")
        {
            Message = "German";
        }
        Subject.BroadcastMessage(Message);
        LabelName.text = IconName.text + "学力";
        Check();
        RedDot.SetActive(false);
    }
}
