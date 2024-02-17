using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BackToSelection : MonoBehaviour
{
    public Flowchart Flowchart;
    public GameObject Camera;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        StartCoroutine(ExampleCoroutine());
        
    }

    IEnumerator ExampleCoroutine()
    {
        Flowchart.ExecuteBlock("白屏");
        yield return new WaitForSeconds(0.25f);
        Camera.transform.position = new Vector3(0f, 0f, Camera.transform.position.z);
    }
    
}
    