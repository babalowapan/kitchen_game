using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(GameoverCheck))]
[RequireComponent(typeof(GameoverCheck_R))]
[RequireComponent(typeof(StopFloor))]

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
    //インスペクターで設定する
    public float speed;
    public StageCheck ground; //new
    public StopFloor st;
    public float gravity;
    //float flap = 1000f;
    public float PlayerX = 0;
    //private float jumpPos = 0.0f;
    //float jumpHeight;
    float Jumppower = 95;
    private Animator anim;
    private bool isGround = false;
    private Rigidbody2D rbody2D = null;
    public static float l_time;
    public GameObject other;
    Vector3 pos;
    Vector3 ago_pos;
    private float Y = -50;
    Vector3 pos_other;
    private bool swap = true;
    public static float l_last_pos;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
        pos = this.gameObject.transform.position;
        pos_other = other.transform.position;
        l_last_pos = 0;
        l_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.y <= Y || pos_other.y <= Y)
        {
            l_last_pos = this.gameObject.transform.position.x;
            anim.SetTrigger("down");
           
        }

        else if (l_time >= 5 || PlayerMove_R.r_time >= 5)
        {
            l_last_pos = this.transform.position.x;
            Debug.Log(l_last_pos);
            anim.SetTrigger("down");
            FadeManager.FadeOut(2);
        }

        else if (Time.timeScale == 1)
        {

            pos = this.gameObject.transform.position;
            pos_other = other.transform.position;
            if (ground.IsGround())//地面に接地しているとき
            {
                rbody2D.velocity = new Vector3(9, rbody2D.velocity.y, 0);
                isGround = true;
                if (swap)
                {
                    if (Input.GetKeyDown(KeyCode.A) || L_button.l_p)//ジャンプのキー入力
                    {
                        //anim.SetTrigger("jumpUp");
                        rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                        L_button.l_p = false;
                    }
                    else
                    {
                        anim.SetBool("run", true);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.D) || R_button.r_p)//ジャンプのキー入力
                    {
                        //anim.SetTrigger("jumpUp");
                        rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                        R_button.r_p = false;
                    }
                    else
                    {
                        anim.SetBool("run", true);
                    }
                }
                if(pos.x == ago_pos.x)
                {
                    l_time += Time.deltaTime;
                }
                else
                {
                    l_time = 0;
                }
                ago_pos = this.gameObject.transform.position;

            }
            
        }
        
    }



    public void SwapKey()
    {
        if (swap)
        {
            swap = false;
        }
        else
        {
            swap = true;
        }
    }
    
}
