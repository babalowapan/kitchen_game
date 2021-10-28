using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	// Start is called before the first frame update
	Rigidbody2D rb;
	BoxCollider2D col;
	private bool check = true;
	private string groundTag = "under_c";
	GameObject s_L;
	GameObject s_R;
	GameObject s_Lk;
	GameObject s_Rk;
	GameObject s;
	private Rez_wall rez_Wall;
	private Rez_wall_v2 rez_Wall_V2;
	GameObject swap;
	public int move_select;	//スイッチと連動させる壁を指定したい
	public int Move_select
    {
        get { return move_select; }
		set { move_select = value; }
    }
	private bool IsPush = false;
	public bool ispush
    {
		get { return IsPush; }
		set { IsPush = value; }
    }

	// Use this for initialization
	void Start()
	{
		rb = this.gameObject.GetComponent<Rigidbody2D>();
		col = this.gameObject.GetComponent<BoxCollider2D>();
		this.rez_Wall = FindObjectOfType<Rez_wall>();
		this.rez_Wall_V2 = FindObjectOfType<Rez_wall_v2>();
		s_L = GameObject.Find("CameraSwap");
		s_R = GameObject.Find("CameraSwap_R");
		s_Lk = GameObject.Find("silver");
		s_Rk = GameObject.Find("gold");
		swap = GameObject.Find("SwapUI");
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (check)
		{
			if (collision.tag == "under_c")
			{
				if (move_select == 2)
				{
					s_L.GetComponent<CameraSwap>().swap_L();
					s_R.GetComponent<CameraSwap_R>().swap_R();
				}
				else if (move_select == 3)
				{
					s_Lk.GetComponent<PlayerMove>().SwapKey();
					s_Rk.GetComponent<PlayerMove_R>().SwapKey();
					swap.GetComponent<SwapUI>().swapUI();
					
				}
				
				check = false;
			}
			IsPush = true;
		}
        else
        {
			IsPush = false;
		}
	}

    void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.tag == groundTag)
		{
			check = true;
			IsPush = false;
		}
    }
}
