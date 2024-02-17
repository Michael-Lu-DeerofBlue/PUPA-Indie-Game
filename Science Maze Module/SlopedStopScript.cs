using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopedStopScript : MonoBehaviour
{
    public List<GameObject> TheStopsThisCanReach;
    public GameObject Player;
    public GameObject PlayersStop;
    public GameObject MazeJudge;
    public GameObject Blocks;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        //先找到Player的位置
        float playerx = Player.transform.position.x;
        float playery = Player.transform.position.y;
        //再找到哪个站点目前上面有玩家
        foreach (Transform blockchild in gameObject.transform.parent)
        {
            if (blockchild.position.x == playerx)
            {
                if (blockchild.position.y == playery)
                {
                    PlayersStop = blockchild.gameObject;
                }
            }
        }
        //再检查这个stop里面有没有目前的这个Stop的数据
        if (PlayersStop != null)
        {
            bool Goable = false;
            List<GameObject> PlayersStopList = PlayersStop.GetComponent<SlopedStopScript>().TheStopsThisCanReach;
            for (int i = 0; i < PlayersStopList.Count; i++)
            {
                if (PlayersStopList[i] == gameObject)
                {
                    Goable = true;
                    break;
                }
            }
            foreach (Transform blockchild in Blocks.transform)
            {
                if (blockchild.position.x == gameObject.transform.position.x)
                {
                    if (blockchild.position.x == gameObject.transform.position.x)
                    {
                        Goable = false;
                        bool PlayersAcid = false;
                        PlayersAcid = Player.GetComponent<PlayerMovementControl>().IsAcid;
                        int Remainder = (MazeJudge.GetComponent<MazeJudgeScript>().Counter + 1) % Player.GetComponent<PlayerMovementControl>().AcidAlkalineFrequency;
                        if (Remainder == 0)
                        {
                            PlayersAcid = !PlayersAcid;
                        }
                        if (PlayersAcid != blockchild.GetComponent<BlockAcidControl>().IsAcid)
                        {
                            Destroy(blockchild.gameObject);
                            Goable = true;
                        }
                        
                    }
                }
            }
            if (Goable == true)
            {
                iTween.MoveTo(Player, iTween.Hash("x", gameObject.transform.position.x, "y", gameObject.transform.position.y, "time", 0.5f, "easetype", iTween.EaseType.easeInOutQuad));
                MazeJudge.GetComponent<MazeJudgeScript>().Counter++;
                int Remainder = MazeJudge.GetComponent<MazeJudgeScript>().Counter % Player.GetComponent<PlayerMovementControl>().AcidAlkalineFrequency;
                if (Remainder == 0)
                {
                    Player.GetComponent<PlayerMovementControl>().IsAcid = !Player.GetComponent<PlayerMovementControl>().IsAcid;
                }
            }
            PlayersStop = null;
        }
    }
}
