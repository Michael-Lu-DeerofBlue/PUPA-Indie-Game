using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Heartbeat : MonoBehaviour
{
    public TextMeshPro HeartbeatLable;
    public int HeartbeatFrequency;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HeartbeatLable.text = HeartbeatFrequency.ToString();
    }
}
