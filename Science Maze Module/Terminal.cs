using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    public bool processed;
    public GameObject Player;
    public string Subject;
    public GameObject Load;
    public string PlayerX;
    public string PlayerY;
    public string TerminalX;
    public string TerminalY;
    public GameObject Congrats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerX = Player.transform.position.x.ToString("F1");
        PlayerY = Player.transform.position.y.ToString("F1");
        TerminalX = gameObject.transform.position.x.ToString("F1");
        TerminalY = gameObject.transform.position.y.ToString("F1");
        if (processed == false)
        {
            if (PlayerX == TerminalX)
            {
                if (PlayerY == TerminalY)
                {
                    Congrats.SetActive(true);
                    if (Subject == "P")
                    {
                        LoadAllCardCode.PhysClueDone = true;
                        LoadAllCardCode.PhysClueStreak++;
                    }
                    else if (Subject == "C")
                    {
                        LoadAllCardCode.ChemClueDone = true;
                        LoadAllCardCode.ChemClueStreak++;
                    }
                    else if (Subject == "B")
                    {
                        LoadAllCardCode.BioClueDone = true;
                        LoadAllCardCode.BioClueStreak++;
                    }
                    Load.GetComponent<LoadAllCardCode>().SaveData();
                    processed = true;
                }
            }
        }
    }
}
