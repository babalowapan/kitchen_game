using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonJump : MonoBehaviour
{
    public StageCheck ground;
    private Animator anim;
    private Rigidbody2D rbody2D = null;
    private bool isGround = false;
    public float Jumppower;
    private GameObject L;
    // Start is called before the first frame update
    void Start()
    {
        L = GameObject.Find("silver");
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonJump_L);
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Vector3 pos = L.transform.position;
    }

    // Update is called once per frame
    public void ButtonJump_L()
    {
        Debug.Log("jump!");
        if (ground.IsGround())//地面に接地しているとき
        {
            isGround = true;            
            Debug.Log("jump");
            anim.SetTrigger("jumpUp");
            rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
        }
        else
        {
            anim.SetBool("run", true);
            anim.SetBool("jumpUp", false);
        }
    }
}