using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typing_Text : MonoBehaviour {
    public Text score_t;
    private int score=0;
	// Use this for initialization
	void Start () {
	
	}
    public void Score(int s) {
        score += s*10;
    }
    public int getScore() {
        return score;
    }
	// Update is called once per frame
	void Update () {
        score_t.text = "SCORE : " + score;
	}
}
