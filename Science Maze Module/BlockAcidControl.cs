using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAcidControl : MonoBehaviour
{
    public bool IsAcid;
    public Sprite Acid;
    public Sprite Alkaline;
    // Update is called once per frame
    void Update()
    {
        if (IsAcid == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Acid;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Alkaline;
        }
    }
}
