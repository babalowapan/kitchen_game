using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	//　ポーズした時に表示するUIのプレハブ
	public GameObject Pause_Restart;
	//　ポーズUIのインスタンス
	private bool pauseUIInstance = false;
    // Update is called once per frame
    void Start()
    {
		Time.timeScale = 1;
		Pause_Restart.SetActive(false);
	}

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{

			if (pauseUIInstance == false)
			{
				Pause_Restart.SetActive(true);
				Time.timeScale = 0f;
				pauseUIInstance = true;
			}
			else
			{
				Pause_Restart.SetActive(false);
				Time.timeScale = 1f;
				pauseUIInstance = false;
			}
		}
	}
}
