using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rez_wall_v2 : MonoBehaviour
{
    private Switch Switch;
    public int num;
    private int check;
    private Vector3 pos;
    private Vector3 target;
    public float moveX;
    public float moveY;
    public float sp = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(num);
        this.Switch = FindObjectOfType<Switch>();
        check = Switch.Move_select;
        pos = this.gameObject.transform.position;
        target = new Vector3(pos.x+moveX, pos.y+moveY,1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Switch.ispush)
        {
            if (Switch.Move_select == num)
            {
                Move();
            }
        }
    }

    void Move()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * sp);
    }
}
