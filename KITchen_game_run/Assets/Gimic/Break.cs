using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject target;
    Vector3 pos;
    Vector3 obj_pos;
    // Start is called before the first frame update
    void Start()
    {
        obj_pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = target.transform.position;
        if (obj_pos.x<=pos.x-50)
        {
            Destroy(this.gameObject);
        }

    }
}
