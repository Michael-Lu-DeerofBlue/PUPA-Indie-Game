using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Door;
    public GameObject TargetStop;
    public GameObject Player;
    public bool Open;
    public bool R;
    public bool L;
    public bool U;
    public bool D;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x == gameObject.transform.position.x && Player.transform.position.y == gameObject.transform.position.y && Open == false)
        {
            if (R)
            {
                TargetStop.GetComponent<StopsScript>().RightWall = false;
            }
            if (L)
            {
                TargetStop.GetComponent<StopsScript>().LeftWall = false;
            }
            if (U)
            {
                TargetStop.GetComponent<StopsScript>().Celling = false;
            }
            if (D)
            {
                TargetStop.GetComponent<StopsScript>().Floor = false;
            }
            Door.SetActive(false);
            Open = true;
        }
    }
}
