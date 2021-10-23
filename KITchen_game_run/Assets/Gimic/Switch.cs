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
	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (check)
		{
			if (collision.tag == groundTag)
			{
				IsPush = true;
				check = false;
				Debug.Log(IsPush);
				Debug.Log(ispush);
			}
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
