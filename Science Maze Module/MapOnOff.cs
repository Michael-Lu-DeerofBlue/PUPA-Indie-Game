using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOnOff : MonoBehaviour
{
    public GameObject Camera;
    public bool ImOn;
    // Start is called before the first frame update
    void Start()
    {
        if (Camera.transform.position.x.ToString("F1") == gameObject.transform.position.x.ToString("F1"))
        {
            if (Camera.transform.position.y.ToString("F1") == gameObject.transform.position.y.ToString("F1"))
            {
                ImOn = true;
            }
        }
        if (ImOn == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void Judge()
    {
        if (Camera.transform.position.x.ToString("F1") == gameObject.transform.position.x.ToString("F1"))
        {
            if (Camera.transform.position.y.ToString("F1") == gameObject.transform.position.y.ToString("F1"))
            {
                ImOn = true;
                gameObject.SetActive(true);
            }
        }
        if (ImOn == false)
        {
            gameObject.SetActive(false);
        }
    }
}
