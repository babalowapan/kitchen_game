using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    public GameObject ground;
    public GameObject rock;
    float setY;

    void CreateStage(float x,float y,float z)
    {
        GameObject instance = (GameObject)Instantiate(ground, new Vector3(x, y, z), Quaternion.identity);
    }

    void CreateRock(float x, float y, float z)
    {
        GameObject instance = (GameObject)Instantiate(rock, new Vector3(x, y, z), Quaternion.identity);
    }

    // Start is called before the first frame update5 -16.5 0
    void Start()
    {
        setY = -10f;
        CreateStage(0.0f, setY, 0.0f);
        CreateStage(25.0f, setY, 0.0f);
        CreateStage(50.0f, setY, 0.0f);
        CreateRock(30f, -3f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}