using UnityEngine;
using System.Collections;

public class T_Manager : MonoBehaviour {
    GameObject gamemain;
   public GameObject deriver;
    GameObject stage_num;
    GameObject gameover;

    public bool game_end = false;
    // Use this for initialization
    void Start () {
        gamemain = GameObject.Find("T_Main");
        gamemain.SetActive(false);
        deriver.SetActive(false);
        stage_num = GameObject.Find("T_Stage");
        stage_num.SetActive(true);
        gameover = GameObject.Find("T_GameOver");
        gameover.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && !gamemain.activeSelf && !game_end)
        {
            gamemain.SetActive(true);
            deriver.SetActive(true);
            stage_num.SetActive(false);
            Debug.Log("でてこい！！");
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (game_end)
            {
                gamemain.SetActive(true);
                deriver.SetActive(true);
                Debug.Log("でてこい！！");
                FindObjectOfType<TypeObject>().Game_Res();
            }
        }

        if (game_end) {
            gameover.SetActive(true);
        }
    }

    public void Wait_Space()
    {
        gamemain.SetActive(false);
        deriver.SetActive(false);
        
        if (!game_end)
        {
            stage_num.SetActive(true);
            Debug.Log("隠れるんだ！！");
        }
    }

 
    public bool getGameMain() {
        return gamemain.activeSelf;
    }

    public void Read() {
        deriver = GameObject.Find("DeriverPoint");
        deriver.SetActive(false);
    }
}
