using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC_KK : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//如果按下ESC键则返回
        {
            GameObject.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("弹出返回页面");
        }
        if (Input.GetKeyDown(KeyCode.P ))//如果按下ESC键则返回
        {
            Time.timeScale = 1;
            GameObject.SetActive(false);
            Debug.Log("弹出返回页面");
        }

    }
}
