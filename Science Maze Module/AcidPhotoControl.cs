using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPhotoControl : MonoBehaviour
{
    public Sprite Acid;
    public Sprite Alkaline;
  

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerMovementControl>().IsAcid)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Acid;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Alkaline ;
        }
    }
}
