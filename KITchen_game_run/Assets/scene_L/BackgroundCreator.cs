using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCreator : MonoBehaviour
{
    public GameObject back;
    float sety;
    public GameObject target;
    Vector3 pos;
    Vector3 back_pos;

    void CreateBack(float x,float y, float z)
    {
        GameObject instance = (GameObject)Instantiate(back, new Vector3(x,y,z), Quaternion.identity);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        sety = -3.8f;
        CreateBack(11, sety, 1);
        CreateBack(87, sety, 1);
        pos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        back_pos = this.gameObject.transform.position;
        pos = target.transform.position;
        /*if (back_pos.x <= pos.x-10)
        {
            Destroy(this.gameObject);
        }*/
    }
}
