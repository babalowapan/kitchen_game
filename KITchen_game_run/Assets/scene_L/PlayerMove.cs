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
    public GameoverCheck gc_L;
    public GameoverCheck_R gc_R;
    public StopFloor st;
    public float gravity;
    float sp = 0.05f;//speed
    float timer  = 0;
    //float flap = 1000f;
    public float PlayerX = 0;
    //private float jumpPos = 0.0f;
    //float jumpHeight;
    public float Jumppower;
    private Animator anim;
    private bool isGround = false;
    private Rigidbody2D rbody2D = null;
    private float move;
    private float reset_time;
    public float time;
    public GameObject other;
    Vector3 pos;
    private float Y = -45;
    Vector3 pos_other;
    private bool swap = true;

    // Start is called before the first frame update
    void Start()
    {
        gc_L = GetComponent<GameoverCheck>();
        gc_R = GetComponent<GameoverCheck_R>();
        st = GetComponentInChildren<StopFloor>();
        characterController = GetComponent<CharacterController>();
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
        pos = this.gameObject.transform.position;
        pos_other = other.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.y <= Y || pos_other.y <= Y)
        {

            anim.SetTrigger("down");
            FadeManager.FadeOut(2);
            Invoke("stop", 0.5f);
            this.gameObject.SetActive(false);
        }

        if (Time.timeScale == 1)
        {
            pos = this.gameObject.transform.position;
            pos_other = other.transform.position;
            if (ground.IsGround())//地面に接地しているとき
            {
                isGround = true;
                if (swap)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift))//ジャンプのキー入力
                    {
                        //anim.SetTrigger("jumpUp");
                        rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                        reset_time = 0;
                    }
                    else
                    {
                        anim.SetBool("run", true);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.RightShift))//ジャンプのキー入力
                    {
                        //anim.SetTrigger("jumpUp");
                        rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                        reset_time = 0;
                    }
                    else
                    {
                        anim.SetBool("run", true);
                    }
                }
            }
            else if (ground.IsGround() == false && rbody2D.velocity.y < 0)//地面に接地してない時
            {
                //anim.SetTrigger("fall");
                isGround = false;
            }

        }
        reset_time += Time.deltaTime;
        timer += Time.deltaTime;
        move = timer * sp;
        rbody2D.velocity = new Vector3(6, rbody2D.velocity.y, 0);
    }
        //Debug.Log(rbody2D.velocity.y);

    void stop()
    {
        Time.timeScale = 0;
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
        Debug.Log(swap);
    }
    
}
