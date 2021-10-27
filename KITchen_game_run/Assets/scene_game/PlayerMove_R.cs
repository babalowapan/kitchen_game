using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
[RequireComponent(typeof(GameoverCheck))]
[RequireComponent(typeof(GameoverCheck_R))]

public class PlayerMove_R : MonoBehaviour
{
    //インスペクターで設定する
    public float speed;
    public StageCheck_R ground; //new
    public float gravity;
    float sp = 0.05f;//speed
    float timer = 0;
    //float flap = 1000f;
    public float PlayerX = 0;
    //private float jumpPos = 0.0f;
    //float jumpHeight;
    float Jumppower = 95;
    private Animator anim;
    private bool isGround = false;
    private Rigidbody2D rbody2D = null;
    private float move;
    public static float time;
    private float Y = -50;
    public GameObject other;
    Vector3 pos;
    Vector3 pos_other;
    private bool swap = true;
    public static float r_last_pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
        pos_other = other.transform.position;
        r_last_pos = 0;

    }


    // Update is called once per frame
    void Update()
    {
        if (pos.y <= Y||pos_other.y <= Y)
        {
            anim.SetTrigger("down");
            time = timer;
            Debug.Log("tttt");
            r_last_pos = this.gameObject.transform.position.x;
            FadeManager.FadeOut(2);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 1)
        {

            if (ground.IsGround())//地面に接地しているとき
            {
                rbody2D.velocity = new Vector3(-9, rbody2D.velocity.y, 0);
                isGround = true;
                if (swap) {
                if (Input.GetKeyDown(KeyCode.D))//ジャンプのキー入力
                {
                    rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                }
                else
                {
                    anim.SetBool("run", true);
                }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.A))//ジャンプのキー入力
                    {
                        //anim.SetBool("run", false);
                        //anim.SetTrigger("jumpUp");
                        rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                    }
                    else
                    {
                        anim.SetBool("run", true);
                    }
                }
            }

            timer += Time.deltaTime;
            move = timer * sp;

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
