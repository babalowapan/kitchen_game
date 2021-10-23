using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	// Start is called before the first frame update
	private string groundTag = "under_c";
	private int move_select;	//スイッチと連動させる壁を指定したい
	public int Move_select
    {
        get { return move_select; }
		set { move_select = value; }
    }
	private bool IsPush = false;
	public bool ispush
    {
		get { return IsPush; }
    }

	// Use this for initialization
	void Start()
	{
		move_select = 1;
	}

	// Update is called once per frame
	void Update()
	{
		if(IsPush == true)
        {
			Debug.Log("Foooo");
        }
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == groundTag)
		{
			IsPush = true;
		}
	}
}
