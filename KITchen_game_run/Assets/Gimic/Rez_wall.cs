using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rez_wall : MonoBehaviour
{
    private Switch Switch;
    public int num = 1;
    private int check;
    private Vector3 pos;
    public float moveX;
    public float moveY;

    // Start is called before the first frame update
    void Start()
    {
        this.Switch = FindObjectOfType<Switch>();
        check = Switch.Move_select;
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Switch.ispush)
        {
            if (Switch.Move_select == num)
            {
                this.gameObject.transform.Translate(moveX,moveY,Time.deltaTime);
            }
        }
    }
}
