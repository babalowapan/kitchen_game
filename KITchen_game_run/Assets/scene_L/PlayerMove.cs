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
    float m_time;
    float minute;

    // Start is called before the first frame update
    void Start()
    {
        gc_L = GetComponent<GameoverCheck>();
        gc_R = GetComponent<GameoverCheck_R>();
        st = GetComponent<StopFloor>();
        characterController = GetComponent<CharacterController>();
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
        minute = 0;
        m_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gc_L.GameOver()||gc_R.GameOver())
        {
            anim.SetTrigger("down");
        }
        else
        {

            if (ground.IsGround())//地面に接地しているとき
            {                isGround = true;
                if (Input.GetKeyDown(KeyCode.LeftShift))//ジャンプのキー入力
                {
                    anim.SetBool("run",false);
                    anim.SetTrigger("jumpUp");
                    rbody2D.AddForce(Vector3.up * Jumppower, ForceMode2D.Impulse);
                    reset_time = 0;
                }
                else
                {
                    anim.SetBool("run", true);
                    anim.SetBool("jumpUp", false);
                }
            }
            else if (rbody2D.velocity.y < 0)//地面に接地してない時
            {
                anim.SetBool("run", false);
                anim.SetTrigger("fall");
                isGround = false;
            }
            else if (st.IsFloor())
            {
                rbody2D.AddForce(Vector3.up * 0);
            }
            
        }

    }

    void FixedUpdate()
    {
        reset_time += Time.deltaTime;
        timer += Time.deltaTime;
        move = timer * sp;
        rbody2D.velocity = new Vector3(5, rbody2D.velocity.y, 0);
    }

    
}
