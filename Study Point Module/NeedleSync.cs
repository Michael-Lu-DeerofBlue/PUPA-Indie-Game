using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleSync : MonoBehaviour
{
    public Image Bar;
    public GameObject Neddle;
    public float Lengthofthebar;
    public float bofofthebar;
    public float ratio;
    public float ypos;
    public bool Big;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Big == true)
        {
            Bar.fillAmount = (LoadAllCardCode.SPSum) / 600;
            float xpos = Bar.fillAmount * Lengthofthebar;
            Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, 0, 0);
        }
    }

    public void Chinese()
    {
        ratio = (float) LoadAllCardCode.ChnSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void Chem()
    {
        ratio = (float)LoadAllCardCode.ChemSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void Bio()
    {
        ratio = (float)LoadAllCardCode.BioSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void Math()
    {
        ratio = (float)LoadAllCardCode.MathSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void Physics()
    {
        ratio = (float)LoadAllCardCode.PhysSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void German()
    {
        ratio = (float)LoadAllCardCode.GerSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void EB()
    {
        ratio = (float)LoadAllCardCode.EBSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }

    public void Econ()
    {
        ratio = (float)LoadAllCardCode.EconSP1 / 100;
        float xpos = ratio * Lengthofthebar;
        Neddle.GetComponent<RectTransform>().anchoredPosition = new Vector3(xpos, ypos, 0);
    }
}
