using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MazeJudgeScript : MonoBehaviour
{
    public int Counter;//代表目前的回合数
    public int CounterMax; //代表最大的回合数
    public bool Gravity; //代表是否开启重力
    public int GravityFrequency; //代表重力的触发频率
    public TextMeshPro GravityFrequencyIndicator;
    public TextMeshPro CounterIndicator;
    public GameObject Blocks;
    public GameObject Player;
    public bool Chem;
    public bool Bio;
    public int AcidAlkalineFrequency;
    // Start is called before the first frame update
    void Start()
    {
        if (Gravity)
        {
            GravityFrequencyIndicator.text = "重力每" + GravityFrequency.ToString() + "轮触发一次";
        }
        else if (Chem)
        {
            GravityFrequencyIndicator.text = "酸碱性每" + AcidAlkalineFrequency.ToString() + "轮变换一次";
        }
        else if (Bio)
        {
            GravityFrequencyIndicator.text = "玩家的心跳为" + Player.GetComponent<Heartbeat>().HeartbeatFrequency.ToString();
        }

    }
    void Update()
    {
        CounterIndicator.text = "移动次数:" + Counter.ToString() + "/" + CounterMax.ToString();
    }

    public void PlusOne()
    {
        if (Gravity == true)
        {
            int Remainder = Counter % GravityFrequency;
            if (Remainder == 0)
            {
                Player.GetComponent<PlayerMovementControl>().ForceDown();
                foreach (Transform blockchild in Blocks.transform)
                {
                    blockchild.GetComponent<BlockScript>().ForceDown();
                }
            }
           
        }
        if (Chem == true)
        {
            int Remainder = Counter % AcidAlkalineFrequency;
            if (Remainder == 0)
            {
                foreach (Transform blockchild in Blocks.transform)
                {
                    //blockchild.GetComponent<BlockAcidControl>().IsAcid = !blockchild.GetComponent<BlockAcidControl>().IsAcid;
                }
            }
        }
    }
}
