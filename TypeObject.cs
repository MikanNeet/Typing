using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//ゲームのマネージャー的な
public class TypeObject : MonoBehaviour {
    public TextMesh textmash;
    public TextMesh alpamesh;
    public Text stage_number;
    TypingSystem ts;
    Dictionary dictionary;
    private int miss_count;
    public int stagenum = 0;

    
	// Use this for initialization
	void Start () {
        dictionary = GetComponent<Dictionary>();
        ts = new TypingSystem();
        dictionary.TextSelect();
        ts.SetInputString(dictionary.getText_());//一般化する
        UpdateText();
        stage_number.text = "STAGE" + (stagenum + 1);

    }

    void UpdateText() {
        textmash.text = "<color=red>" + ts.GetInputedString() + "</color>" + ts.GetRestString();
        alpamesh.text = "<color=red>" + ts.GetInputedKey() + "</color>" + ts.GetRestKey();
        
    }
    // Update is called once per frame
    void Update() {

        string[] keys = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "-", "," };
        if (!FindObjectOfType<T_Manager>().game_end) { 
            foreach (string key in keys) {
                if (Input.GetKeyDown(key)) {
                    if (ts.InputKey(key) == 1)
                    {
                        UpdateText();
                    }
                    else {
                        miss_count++;
                        FindObjectOfType<Typing_Text>().Score(-1);
                        FindObjectOfType<Timer>().Miss();
                        //ここで音出したい
                    }
                    break;
                }
            }
    }
        //ゲーム終了条件・ステージ終了条件予定20語ずつにしようかな
        if (ts.GetRestString() == "" && FindObjectOfType<Dictionary>().getCnt() == 5)
        {


            B_StageNum stage_score;//B_StageNumのインスタンス作成
            stage_score = GameObject.Find("DeriverPoint").GetComponent<B_StageNum>();//コンポーネント取得
            stage_score.score[stagenum] = FindObjectOfType<Typing_Text>().getScore() / 10 - stage_score.since_score_;//各ステージの取得金
            stage_score.since_score_ += stage_score.score[stagenum];//総取得金に加算

            if (stagenum != 1)
            {
                FindObjectOfType<Dictionary>().resetCnt();
                stagenum++;
                FindObjectOfType<Dictionary>().Stage_Up();
                FindObjectOfType<T_Manager>().Wait_Space();
                stage_number.text = "STAGE" + (stagenum + 1);
            }
            else
            {
                FindObjectOfType<T_Manager>().game_end = true;
                FindObjectOfType<T_Manager>().Wait_Space();
            }
        }
        else if (ts.GetRestString() == "" && FindObjectOfType<Dictionary>().getCnt() != 5)
        {
            //文字列の長さにより取得点増減
            FindObjectOfType<Timer>().Success();
            FindObjectOfType<Typing_Text>().Score(FindObjectOfType<Dictionary>().getText_().Length);
            dictionary.TextSelect();//文字選ぶ
            ts.SetInputString(dictionary.getText_());//一般化する
            UpdateText();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Main");
        }
       
        if (FindObjectOfType<T_Manager>().getGameMain()==true) {
            if (FindObjectOfType<Timer>().time <= 0)
            {
                //Application.LoadLevel("T_GameOver");
            }
        }



    }

    public void Game_Res() {
        Application.LoadLevel("Game_Result");
    }
}
