﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
    }
}
