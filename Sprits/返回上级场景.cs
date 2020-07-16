using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 返回上级场景 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Escape))//如果按下ESC键则返回
        {
            Debug.Log("return");
            this.GetComponent<Button>().onClick.Invoke();
        }*/
        //if (Input.GetKeyDown(KeyCode.))
        //{

        //}
    }
    public void GhangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
