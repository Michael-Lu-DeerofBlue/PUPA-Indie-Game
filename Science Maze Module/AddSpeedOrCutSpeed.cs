using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedOrCutSpeed : MonoBehaviour
{
    public bool Add;
    public GameObject Player;
    public bool Eaten;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x.ToString("F2") == gameObject.transform.position.x.ToString("F2") && 
            Player.transform.position.y.ToString("F2") == gameObject.transform.position.y.ToString("F2") && Eaten == false)
        {
            if (Add == true)
            {
                Player.GetComponent<Heartbeat>().HeartbeatFrequency++;
            }
            else
            {
                Player.GetComponent<Heartbeat>().HeartbeatFrequency--;
            }            
            Eaten = true;
            gameObject.SetActive(false);
        }
    }
}
