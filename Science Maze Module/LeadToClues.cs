using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class LeadToClues : MonoBehaviour
{
    public string subject;
    public bool R5;
    public int CameraX;
    public float CameraY;
    public GameObject Camera;
    public GameObject Maps;
    public Flowchart Flowchart;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (R5 == true)
        {
            subject = PlayerPrefs.GetString("_Row5 Selection");
        }
        else
        {
            subject = PlayerPrefs.GetString("_Row6 Selection");
        }
        if (LeftEnergy.RoundNum == 1 || LeftEnergy.RoundNum ==2)
        {
            CameraX = 0;
        }
        else if (LeftEnergy.RoundNum == 3 || LeftEnergy.RoundNum == 4)
        {
            CameraX = 22;
        }
        else if (LeftEnergy.RoundNum == 5 || LeftEnergy.RoundNum == 6)
        {
            CameraX = 44;
        }
        else if (LeftEnergy.RoundNum == 7 || LeftEnergy.RoundNum == 8)
        {
            CameraX = 66;
        }
        CameraY = 0;
        if (subject == "Physics")
        {
            CameraY = -12.6f;
            if (LoadAllCardCode.PhysClueDone == false)
            {
                StartCoroutine(ExampleCoroutine());
            }
        }
        else if (subject == "Chem")
        {
            CameraY = -25.2f;
            if (LoadAllCardCode.ChemClueDone == false)
            {
                StartCoroutine(ExampleCoroutine());
            }
        }
        else if (subject == "Bio")
        {
            CameraY = -37.8f;
            if (LoadAllCardCode.BioClueDone == false)
            {
                StartCoroutine(ExampleCoroutine());
            }
        }

        IEnumerator ExampleCoroutine()
        {
            Flowchart.ExecuteBlock("白屏");
            yield return new WaitForSeconds(0.25f);
            Camera.transform.position = new Vector3(CameraX, CameraY, Camera.transform.position.z);
            foreach (Transform child in Maps.transform)
            {
                child.gameObject.SetActive(true);
            }
            Maps.transform.BroadcastMessage("Judge");
        }
    }
}
