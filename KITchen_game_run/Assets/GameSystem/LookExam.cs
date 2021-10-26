using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LookExam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(lookExam);
    }

    // Update is called once per frame
    void lookExam()
    {
        FadeManager.FadeOut(3);
    }
}
