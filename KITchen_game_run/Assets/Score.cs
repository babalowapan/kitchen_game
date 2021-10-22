using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		time = Timer.score_t;
		T_time = Timer.time;
		Debug.Log(T_time);
	}

	

}
