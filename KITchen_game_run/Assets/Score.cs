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
	float time;
	string T_time;
	float score;
	private Text ScoreText;

	void Start()
	{
		FadeManager.FadeIn();
		ScoreText = GetComponent<Text>();
		time = Timer.score_t;
		T_time = time.ToString("00");
		Debug.Log(T_time);
	}

    void Update()
    {
		ScoreText.text = T_time;
	}

}
