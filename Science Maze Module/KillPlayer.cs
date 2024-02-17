using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer: MonoBehaviour
{
    public bool processed;
    public GameObject Player;
    public GameObject Heartbeat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (processed == false)
        {
            if (Player.transform.position.x.ToString("F2") == gameObject.transform.position.x.ToString("F2"))
            {
                if (Player.transform.position.y.ToString("F2") == gameObject.transform.position.y.ToString("F2"))
                {
                    Player.SetActive(false);
                    Heartbeat.SetActive(false);
                    processed = true;
                }
            }
        }
    }
}
