using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    private Switch Switch;
    public GameObject playerObj;
    public Camera cam;
    private Matrix4x4 mat;
    Vector3 scale;
    private bool swap;
    public int move_num = 2;

    // Start is called before the first frame update
    void Start()
    {
        this.Switch = FindObjectOfType<Switch>();
        scale = new Vector3(-1, 1, 1);
        swap = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Switch.ispush)
        {
            if (Switch.Move_select == move_num)
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

        if (swap)
            {
                cam.ResetWorldToCameraMatrix();
                cam.ResetProjectionMatrix();
                cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
                cam.rect = new Rect(0.5f, 0, 0.5f, 1.0f);
            }
            else
            {
                cam.ResetWorldToCameraMatrix();
                cam.ResetProjectionMatrix();
                cam.rect = new Rect(0, 0, 0.5f, 1.0f);
            }

            
    }

    void OnPreRender()
    {
        if (scale.x * scale.y * scale.z < 0)
        {
            GL.invertCulling = true;
        }
    }

    void OnPostRender()
    {
        GL.invertCulling = false;
    }

}

