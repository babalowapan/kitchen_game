using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap_R : MonoBehaviour
{
    public GameObject playerObj;
    public Camera cam;
    private Matrix4x4 mat;
    Vector3 scale;
    float timer;
    private bool swap;

    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(-1, 1, 1);
        swap = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            if (swap)
            {
                cam.ResetWorldToCameraMatrix();
                cam.ResetProjectionMatrix();
                cam.projectionMatrix = cam.projectionMatrix * Matrix4x4.Scale(scale);
                cam.rect = new Rect(0, 0, 0.5f, 1.0f);
                timer = 0;
            }
            else
            {
                cam.ResetWorldToCameraMatrix();
                cam.ResetProjectionMatrix();
                timer = 0;
                cam.rect = new Rect(0.5f, 0, 0.5f, 1.0f);
            }

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