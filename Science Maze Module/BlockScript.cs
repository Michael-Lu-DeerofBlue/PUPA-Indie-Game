using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject Stops;
    public GameObject Player;
    public List<float> CorrodinateList;
    public float MovingTime;
   
    public void ForceDown()
    {
        Player.GetComponent<PlayerMovementControl>().InForceDown = true;
        StartCoroutine(ExampleCoroutine());
        
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(MovingTime + 0.8f);
        bool goAble = true;
        bool haveStop = false;
        float ypos = 0;
        foreach (Transform stopchild in Stops.transform)
        {
            if (stopchild.position.x.ToString("F2") == gameObject.transform.position.x.ToString("F2"))
            {
                if (stopchild.position.y < gameObject.transform.position.y)
                {
                    haveStop = true;
                    CorrodinateList.Add(stopchild.position.y);
                }
                else if (stopchild.position.y.ToString("F2") == gameObject.transform.position.y.ToString("F2"))
                {
                    if (stopchild.GetComponent<StopsScript>().Floor == true)
                    {
                        goAble = false;
                    }
                }
            }
        }
        if (haveStop == true)
        {
            CorrodinateList.Sort();
            CorrodinateList.Reverse();
            ypos = CorrodinateList[0];
            if (Player.transform.position.y == ypos)
            {
                if (Player.transform.position.x == gameObject.transform.position.x)
                {
                    goAble = false;
                }
            }
        }
        if (haveStop == true && goAble == true)
        {
            iTween.MoveTo(gameObject, iTween.Hash("y", ypos, "time", MovingTime, "easetype", iTween.EaseType.easeInOutQuad));
            CorrodinateList.Clear();
        }
        if (CorrodinateList != null)
        {
            CorrodinateList.Clear();
        }
        yield return new WaitForSeconds(MovingTime);
        Player.GetComponent<PlayerMovementControl>().InForceDown = false;
    }
}
