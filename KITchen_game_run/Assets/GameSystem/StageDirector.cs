using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDirector : MonoBehaviour
{
    GameObject target1;
    GameObject target2;
    public GameObject s1_l;
    public GameObject s1_r;
    public GameObject s2_l;
    public GameObject s2_r;
    public GameObject s3_l;
    public GameObject s3_r;
    Vector3 pos1;
    Vector3 pos2;
    float f_pos;
    float pos= 300;
    float check_pos = 200;
    int st_len = 13;
    GameObject tar_l;
    GameObject tar_r;
    int i = 0;
    bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        target1 = GameObject.Find("silver");
        target2 = GameObject.Find("gold");
        check_pos += f_pos;
        Random.InitState(System.DateTime.Now.Millisecond);

    }

    // Update is called once per frame
    void Update()
    {
        pos1 = target1.transform.position;
        pos2 = target2.transform.position;
        if(pos1.x >= check_pos || pos2.x <= check_pos * -1)
        {
            if (check)
            {
                i = Random.Range(7, st_len + 1);
            }
            else
            {
                i++;
            }

            if (i==13)
            {
                check = true;
            }
            
            StageCreate(i, pos);
            check_pos += 390;
            pos += 390;
        }

    }

    void StageCreate(int x, float y)
    {
       
        if (x == 1)
        {
            tar_l = s1_l;
            tar_r = s1_r;
        }
        else if (x == 2)
        {
            tar_l = s2_l;
            tar_r = s2_r;
        }
        else if (x == 3)
        {
            tar_l = s3_l;
            tar_r = s3_r;
        }

        Instantiate(tar_l, new Vector3(y,0,1), Quaternion.identity);
        Instantiate(tar_r, new Vector3(y*-1,0,1), Quaternion.identity);
    }
}
