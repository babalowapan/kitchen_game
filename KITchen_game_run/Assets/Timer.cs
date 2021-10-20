using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField]
	private int minute;
	[SerializeField]
	private float seconds;
	//　前のUpdateの時の秒数
	private float oldSeconds;
	//　タイマー表示用テキスト
	private Text timerText;
	public static float score_t;
	public static string time;

	void Start()
	{
		minute = 0;
		seconds = 0f;
		oldSeconds = 0f;
		timerText = GetComponent<Text>();
	}

	void Update()
	{
		if (GameoverCheck_R.Over_R||GameoverCheck.Over_L)
		{
			score_t = seconds;
			time = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			Debug.Log(score_t);
		}
		seconds += Time.deltaTime;
		if (seconds >= 60f)
		{
			minute++;
			seconds = seconds - 60;
		}
		//　値が変わった時だけテキストUIを更新
		if ((int)seconds != (int)oldSeconds)
		{
			timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
		}
		oldSeconds = seconds;
	}
}