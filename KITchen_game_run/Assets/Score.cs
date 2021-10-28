using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	// Start is called before the first frame update
	//　前のUpdateの時の秒数
	//　タイマー表示用テキスト
	float l_pos;
	float r_pos;
	float time;
	string T_time;
	float score;
	private Text ScoreText;

	void Start()
	{
		FadeManager.FadeIn();
		ScoreText = GetComponent<Text>();
		score = PlayerMove.l_last_pos;
		Debug.Log(score);
		if (score <= PlayerMove_R.r_last_pos * -1)
        {
			score = PlayerMove_R.r_last_pos * -1;
		}
		score = score / 10;
		T_time = "Score:" + score.ToString("00");
		Debug.Log(T_time);
	}

    void Update()
    {
		ScoreText.text = T_time;
	}

}
