using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	//　ポーズした時に表示するUIのプレハブ
	public GameObject Pause_RestartPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{

			if (pauseUIInstance == null)
			{
				pauseUIInstance = GameObject.Instantiate(Pause_RestartPrefab) as GameObject;
				Time.timeScale = 0f;
			}
			else
			{
				Destroy(pauseUIInstance);
				Time.timeScale = 1f;
			}
		}
	}
}
