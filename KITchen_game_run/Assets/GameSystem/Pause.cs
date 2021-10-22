using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	//　ポーズした時に表示するUIのプレハブ
	public GameObject Pause_RestartPrefab;
	//　ポーズUIのインスタンス
	private bool pauseUIInstance = false;
    // Update is called once per frame
    void Start()
    {
		Time.timeScale = 1;
	}

    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{

			if (pauseUIInstance == false)
			{
				Pause_RestartPrefab.SetActive(true);
				Time.timeScale = 0f;
				pauseUIInstance = true;
				Instantiate(Pause_RestartPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			}
			else
			{
				Pause_RestartPrefab.SetActive(false);
				Time.timeScale = 1f;
				pauseUIInstance = false;
				Destroy(Pause_RestartPrefab);
			}
		}
	}
}
