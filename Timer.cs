using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ((int)time).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        GetComponent<Text>().text = ((int)time).ToString()+"秒";

        if (time <= 0) {
            FindObjectOfType<T_Manager>().game_end = true;
            time = 0;
        }

    }

    public void Miss() {
        time -= 5f;
    }


    public void Success() {
        time += 10f;
    }
}
