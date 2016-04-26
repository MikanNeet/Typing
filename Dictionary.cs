using UnityEngine;
using System.Collections;


public class Dictionary : MonoBehaviour {
    public const int max=20;
    public string[] name_=new string[max];
    public bool[] flag = new bool[max];
    private  static string draw_text;
    private int num;
    private int cnt = 0;
    private int stage;
    // Use this for initialization


    void Start()
    {
        Stage_Up();
    }


    public void TextSelect()
    {

        Debug.Log(stage+"番目");
        num = (int)(Random.Range(0 + stage * 10, 10 + stage * 10));
        while (flag[num])
        {
            num = (int)(Random.Range(0 + stage * 10, 10 + stage * 10));
        }
        draw_text = name_[num];
        flag[num] = true;
        cnt++;//出力した文字列の数
    }

    //今何個目かを返す
    public int getCnt() {
        return cnt;
    }
    //今何個目かを返す
    public void resetCnt()
    {
        cnt = 0;
    }
    //文字列の最大数を返す
    public int getMax() {
        return max;
    }
    
    //表示テキストをリターン
    public string getText_() {
        return draw_text;
    }
	// Update is called once per frame
	void Update () {
        Stage_Up();
    }
    public void Stage_Up()
    {
        stage = FindObjectOfType<TypeObject>().stagenum;
    }

}
