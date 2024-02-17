using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl : MonoBehaviour
{
    public GameObject Stops;
    public GameObject Blocks;
    public GameObject Diodes;
    public GameObject MazeJudge;
    public List<float> CorrodinateList;
    public float MovingTime;
    public bool Done;
    public bool TimerDone;
    public bool InForceDown;
    public string Direction;
    public bool DiodeGoable;
    public bool IsAcid;
    public bool goAble;
    public int AcidAlkalineFrequency;
    public int Remainder;
    public bool Sloped;
    public bool BioLock;
    // Start is called before the first frame update
    void Start()
    {
        AcidAlkalineFrequency = MazeJudge.GetComponent<MazeJudgeScript>().AcidAlkalineFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        bool W = Input.GetKeyDown(KeyCode.W);
        bool A = Input.GetKeyDown(KeyCode.A);
        bool S = Input.GetKeyDown(KeyCode.S);
        bool D = Input.GetKeyDown(KeyCode.D);
        if (MazeJudge.GetComponent<MazeJudgeScript>().Counter < MazeJudge.GetComponent<MazeJudgeScript>().CounterMax 
            && TimerDone == false && InForceDown == false && Sloped == false)
        {
            if (gameObject.GetComponent<AcidPhotoControl>().enabled == true)
            {
                Remainder = (MazeJudge.GetComponent<MazeJudgeScript>().Counter + 1) % AcidAlkalineFrequency;
            }
            if (W == true)
            {
                StartCoroutine(Timer());
                Done = true;
                Up();
                if (gameObject.GetComponent<Heartbeat>().enabled == true)
                {
                    StartCoroutine(DelayedUp());
                }
            }
            if (D == true)
            {
                StartCoroutine(Timer());
                Done = true;
                Right();
                if (gameObject.GetComponent<Heartbeat>().enabled == true)
                {
                    StartCoroutine(DelayedRight());
                }
            }
            if (A == true)
            {
                StartCoroutine(Timer());
                Done = true;
                Left();
                if (gameObject.GetComponent<Heartbeat>().enabled == true)
                {
                    StartCoroutine(DelayedLeft());
                }
            }
            if (S == true)
            {
                StartCoroutine(Timer());
                Done = true;
                Down();
                if (gameObject.GetComponent<Heartbeat>().enabled == true)
                {
                    StartCoroutine(DelayedDown());
                }
            }
        }
    }

    public void Up()
    {
        Direction = "Up";
        goAble = true;
        bool haveStop = false;
        DiodeGoable = true;
        float ypos = 0;
        foreach (Transform stopchild in Stops.transform)
        {
            if (stopchild.position.x == gameObject.transform.position.x)
            {
                if (stopchild.position.y > gameObject.transform.position.y)
                {
                    haveStop = true;
                    CorrodinateList.Add(stopchild.position.y);
                }
                else if (stopchild.position.y == gameObject.transform.position.y)
                {
                    if (stopchild.GetComponent<StopsScript>().Celling == true)
                    {
                        goAble = false;
                    }
                }
            }
        }
        if (haveStop == true)
        {
            CorrodinateList.Sort();
            ypos = CorrodinateList[0];
            foreach (Transform blockchild in Blocks.transform)
            {
                if (blockchild.position.y.ToString("F2") == ypos.ToString("F2"))
                {
                    if (blockchild.position.x.ToString("F2") == gameObject.transform.position.x.ToString("F2"))
                    {
                        goAble = false;
                        if (gameObject.GetComponent<AcidPhotoControl>().enabled == true)//如果是化学的解谜
                        {
                            bool x = blockchild.GetComponent<BlockAcidControl>().IsAcid;
                            bool y = IsAcid;
                            if (x != y)
                            {
                                goAble = true;
                                Destroy(blockchild.gameObject);
                            }
                        }
                    }
                }
            }
            //Diode();
        }
        if (haveStop == true && goAble == true && DiodeGoable == true)
        {
            if (Remainder == 0)
            {
                IsAcid = !IsAcid;
            }
            iTween.MoveTo(gameObject, iTween.Hash("y", ypos, "time", MovingTime, "easetype", iTween.EaseType.easeInOutQuad));
            CorrodinateList.Clear();
            if (BioLock)
            {
                BioLock = false;
            }
            else
            {
                MazeJudge.GetComponent<MazeJudgeScript>().Counter++;
            }
            MazeJudge.GetComponent<MazeJudgeScript>().PlusOne();
        }
        if (CorrodinateList != null)
        {
            CorrodinateList.Clear();
        }
        Done = false;
        Direction = "";
    }
    public void Down()
    {
        Direction = "Down";
        goAble = true;
        bool haveStop = false;
        DiodeGoable = true;
        float ypos = 0;
        foreach (Transform stopchild in Stops.transform)
        {
            if (stopchild.position.x == gameObject.transform.position.x)
            {
                if (stopchild.position.y < gameObject.transform.position.y)
                {
                    haveStop = true;
                    CorrodinateList.Add(stopchild.position.y);
                }
                else if (stopchild.position.y == gameObject.transform.position.y)
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
            foreach (Transform blockchild in Blocks.transform)
            {
                if (blockchild.position.y.ToString("F2") == ypos.ToString("F2"))
                {
                    if (blockchild.position.x.ToString("F2") == gameObject.transform.position.x.ToString("F2"))
                    {
                        goAble = false;
                        if (gameObject.GetComponent<AcidPhotoControl>().enabled == true)//如果是化学的解谜
                        {
                            bool x = blockchild.GetComponent<BlockAcidControl>().IsAcid;
                            bool y = IsAcid;
                            if (x != y)
                            {
                                goAble = true;
                                Destroy(blockchild.gameObject);
                            }
                        }
                    }
                }
            }
            //Diode();
        }
        if (haveStop == true && goAble == true && DiodeGoable == true)
        {
            if (Remainder == 0)
            {
                IsAcid = !IsAcid;
            }
            iTween.MoveTo(gameObject, iTween.Hash("y", ypos, "time", MovingTime, "easetype", iTween.EaseType.easeInOutQuad));
            CorrodinateList.Clear();
            if (BioLock)
            {
                BioLock = false;
            }
            else
            {
                MazeJudge.GetComponent<MazeJudgeScript>().Counter++;
            }
            MazeJudge.GetComponent<MazeJudgeScript>().PlusOne();
        }
        if (CorrodinateList != null)
        {
            CorrodinateList.Clear();
        }
        Done = false;
        Direction = "";
    }
    public void Right()
    {
        Direction = "Right";
        goAble = true;
        bool haveStop = false;
        DiodeGoable = true;
        float xpos = 0;
        foreach (Transform stopchild in Stops.transform)
        {
            if (stopchild.position.y == gameObject.transform.position.y)
            {
                if (stopchild.position.x > gameObject.transform.position.x)
                {
                    haveStop = true;
                    CorrodinateList.Add(stopchild.position.x);
                }
                else if (stopchild.position.x == gameObject.transform.position.x)
                {
                    if (stopchild.GetComponent<StopsScript>().RightWall == true)
                    {
                        goAble = false;
                    }
                }
            }
        }
        if (haveStop == true)
        {
            CorrodinateList.Sort();
            xpos = CorrodinateList[0];
            foreach (Transform blockchild in Blocks.transform)
            {
                if (blockchild.position.x.ToString("F2") == xpos.ToString("F2"))
                {
                    if (blockchild.position.y.ToString("F2") == gameObject.transform.position.y.ToString("F2"))
                    {
                        goAble = false;
                        if (gameObject.GetComponent<AcidPhotoControl>().enabled == true)//如果是化学的解谜
                        {
                            bool x = blockchild.GetComponent<BlockAcidControl>().IsAcid;
                            bool y = IsAcid;
                            if (x != y)
                            {
                                goAble = true;
                                Destroy(blockchild.gameObject);
                            }
                        }
                    }
                }
            }
            //Diode();
            Direction = "";
        }
        if (haveStop == true && goAble == true && DiodeGoable == true)
        {
            if (Remainder == 0)
            {
                IsAcid = !IsAcid;
            }
            iTween.MoveTo(gameObject, iTween.Hash("x", xpos, "time", MovingTime, "easetype", iTween.EaseType.easeInOutQuad));
            CorrodinateList.Clear();
            if (BioLock)
            {
                BioLock = false;
            }
            else
            {
                MazeJudge.GetComponent<MazeJudgeScript>().Counter++;
            }
            MazeJudge.GetComponent<MazeJudgeScript>().PlusOne();
        }
        if (CorrodinateList != null)
        {
            CorrodinateList.Clear();
        }
        Done = false;
    }
    public void Left()
    {
        Direction = "Left";
        goAble = true;
        bool haveStop = false;
        DiodeGoable = true;
        float xpos = 0;
        foreach (Transform stopchild in Stops.transform)
        {
            if (stopchild.position.y == gameObject.transform.position.y)
            {
                if (stopchild.position.x < gameObject.transform.position.x)
                {
                    haveStop = true;
                    CorrodinateList.Add(stopchild.position.x);
                }
                else if (stopchild.position.x == gameObject.transform.position.x)
                {
                    if (stopchild.GetComponent<StopsScript>().LeftWall == true)
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
            xpos = CorrodinateList[0];
            foreach (Transform blockchild in Blocks.transform)
            {
                if (blockchild.position.x.ToString("F2") == xpos.ToString("F2"))
                {
                    if (blockchild.position.y.ToString("F2") == gameObject.transform.position.y.ToString("F2"))
                    {
                        goAble = false;
                        if (gameObject.GetComponent<AcidPhotoControl>().enabled == true)//如果是化学的解谜
                        {
                            bool x = blockchild.GetComponent<BlockAcidControl>().IsAcid;
                            bool y = IsAcid;
                            if (x != y)
                            {
                                goAble = true;
                                Destroy(blockchild.gameObject);
                            }
                        }
                    }
                }
            }
            //Diode();
        }
        if (haveStop == true && goAble == true && DiodeGoable == true)
        {
            if (Remainder == 0)
            {
                IsAcid = !IsAcid;
            }
            iTween.MoveTo(gameObject, iTween.Hash("x", xpos, "time", MovingTime, "easetype", iTween.EaseType.easeInOutQuad));
            CorrodinateList.Clear();
            if (BioLock)
            {
                BioLock = false;
            }
            else
            {
                MazeJudge.GetComponent<MazeJudgeScript>().Counter++;
            }
            MazeJudge.GetComponent<MazeJudgeScript>().PlusOne();
        }
        if (CorrodinateList != null)
        {
            CorrodinateList.Clear();
        }
        Done = false;
        Direction = "";
    }
    public void ForceDown()
    {
        Done = true;
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(MovingTime + 0.5f);
        bool goAble = true;
        bool haveStop = false;
        float ypos = 0;
        foreach (Transform stopchild in Stops.transform)
        {
            if (stopchild.position.x == gameObject.transform.position.x)
            {
                if (stopchild.position.y < gameObject.transform.position.y)
                {
                    haveStop = true;
                    CorrodinateList.Add(stopchild.position.y);
                }
                else if (stopchild.position.y == gameObject.transform.position.y)
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
            foreach (Transform blockchild in Blocks.transform)
            {
                if (blockchild.position.y.ToString("F2") == ypos.ToString("F2"))
                {
                    if (blockchild.position.x.ToString("F2") == gameObject.transform.position.x.ToString("F2"))
                    {
                        goAble = false;
                    }
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
        Done = false;
        TimerDone = false;
    }
    IEnumerator Timer()
    {
        TimerDone = true;
        yield return new WaitForSeconds(MovingTime + 0.1f);
        TimerDone = false;
    }

    void Diode()
    {
        Debug.Log("here");
        if (Direction == "Right")
        {
            foreach (Transform diodechild in Diodes.transform)
            {
                if (diodechild.position.y == gameObject.transform.position.y)
                {
                    float NextStop = CorrodinateList[0];
                    float diodepos = diodechild.position.x;
                    if (diodepos > gameObject.transform.position.x && diodepos < NextStop)//有二极管
                    {
                        if (diodechild.GetComponent<DiodeScript>().FromLeft == true)
                        {
                            DiodeGoable = true;
                        }
                        else
                        {
                            DiodeGoable = false;
                        }
                    }
                }
            }
        }
        else if (Direction == "Left")
        {
            Debug.Log("here");
            foreach (Transform diodechild in Diodes.transform)
            {
                if (diodechild.position.y == gameObject.transform.position.y)
                {
                    float NextStop = CorrodinateList[0];
                    float diodepos = diodechild.position.x;
                    if (diodepos < gameObject.transform.position.x && diodepos > NextStop)//有二极管
                    {
                        Debug.Log("here");
                        if (diodechild.GetComponent<DiodeScript>().FromRight == true)
                        {
                            Debug.Log("here");
                            DiodeGoable = true;
                        }
                        else
                        {
                            Debug.Log("here");
                            DiodeGoable = false;
                        }
                    }
                }
            }
        }
        else if (Direction == "Up")
        {
            foreach (Transform diodechild in Diodes.transform)
            {
                if (diodechild.position.x == gameObject.transform.position.x)
                {
                    float NextStop = CorrodinateList[0];
                    float diodepos = diodechild.position.y;
                    if (diodepos > gameObject.transform.position.y && diodepos < NextStop)//有二极管
                    {
                        if (diodechild.GetComponent<DiodeScript>().FromDown == true)
                        {
                            DiodeGoable = true;
                        }
                        else
                        {
                            DiodeGoable = false;
                        }
                    }
                }
            }
        }
        else if (Direction == "Down")
        {
            foreach (Transform diodechild in Diodes.transform)
            {
                if (diodechild.position.x == gameObject.transform.position.x)
                {
                    float NextStop = CorrodinateList[0];
                    float diodepos = diodechild.position.y;
                    if (diodepos < gameObject.transform.position.y && diodepos > NextStop)//有二极管
                    {
                        if (diodechild.GetComponent<DiodeScript>().FromUp == true)
                        {
                            DiodeGoable = true;
                        }
                        else
                        {
                            DiodeGoable = false;
                        }
                    }
                }
            }
        }
    }
    void AcidAlkalineJudge()
    {

    }

    IEnumerator DelayedUp()
    {
        int Counter = gameObject.GetComponent<Heartbeat>().HeartbeatFrequency - 1;
        for (int i = 1; i <= Counter; i++)
        {
            yield return new WaitForSeconds(MovingTime + 0.5f);
            BioLock = true;
            Up();
        }
    }
    IEnumerator DelayedRight()
    {
        int Counter = gameObject.GetComponent<Heartbeat>().HeartbeatFrequency - 1;
        for (int i = 1; i <= Counter; i++)
        {
            yield return new WaitForSeconds(MovingTime + 0.5f);
            BioLock = true;
            Right();
        }
    }
    IEnumerator DelayedDown()
    {
        int Counter = gameObject.GetComponent<Heartbeat>().HeartbeatFrequency - 1;
        for (int i = 1; i <= Counter; i++)
        {
            yield return new WaitForSeconds(MovingTime + 0.5f);
            BioLock = true;
            Down();
        }
    }
    IEnumerator DelayedLeft()
    {
        int Counter = gameObject.GetComponent<Heartbeat>().HeartbeatFrequency - 1;
        for (int i = 1; i <= Counter; i++)
        {
            yield return new WaitForSeconds(MovingTime + 0.5f);
            BioLock = true;
            Left();
        }
    }
}
