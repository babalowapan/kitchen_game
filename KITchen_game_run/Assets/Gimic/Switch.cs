using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject[] OnObj;
	public GameObject[] OffObj;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Player")
		{
			foreach (GameObject On in OnObj)
			{
				On.GetComponent<SpriteRenderer>().enabled = true;
				On.GetComponent<Collider2D>().enabled = true;
			}
			foreach (GameObject Off in OffObj)
			{
				Off.GetComponent<SpriteRenderer>().enabled = false;
				Off.GetComponent<Collider2D>().enabled = false;
			}
			Destroy(this.gameObject);
		}
	}
}
