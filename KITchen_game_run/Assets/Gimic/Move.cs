using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float PosY;
    float time;
    private Rigidbody2D rb;
    bool check = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 3f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3)
        {
            if (check)
            {
                rb.velocity = new Vector3(0, -3f, 0);
                check = false;
                time = 0;
            }
            else
            {
                rb.velocity = new Vector3(0, 3f, 0);
                check = true;
                time = 0;
            }
            
        }
        //transform.position = new Vector3(transform.position.x, PosY + Mathf.PingPong(Time.time * 2f, 3), transform.position.z);
    }
}
