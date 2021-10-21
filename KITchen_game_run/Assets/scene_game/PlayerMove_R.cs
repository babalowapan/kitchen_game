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
    public GameoverCheck gc_L;
    public GameoverCheck_R gc_R;
    public float gravity;
    float sp = 0.05f;//speed
    float timer = 0;
    //float flap = 1000f;
    public float PlayerX = 0;
    //private float jumpPos = 0.0f;
    //float jumpHeight;
    public float Jumppower;
    private Animator anim;
    private bool isGround = false;
    private Rigidbody2D rbody2D = null;
    private float move;
    public static float time;

    // Start is called before the first frame update
    void Start()
    {
        gc_L = GetComponent<GameoverCheck>();
        gc_R = GetComponent<GameoverCheck_R>();
        rbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("run", false);
    }


    // Update is called once per frame
    void Update()
    {
        if (gc_L.GameOver() || gc_R.GameOver())
        {
            anim.SetTrigger("down");
            time = timer;
        }
        else
        {

            if (ground.IsGround())//地面に接地しているとき
            {
                isGround = true;
                if (Input.GetKeyDown(KeyCode.RightShift))//ジャンプのキー入力
                {
                    anim.SetBool("run", false);
                    anim.SetTrigger("jumpUp");
                    rbody2D.AddForce(Vector2.up * Jumppower, ForceMode2D.Impulse);
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

            timer += Time.deltaTime;
            move = timer * sp;
            rbody2D.velocity = new Vector3(-6, rbody2D.velocity.y, 0);

        }
    }

}
