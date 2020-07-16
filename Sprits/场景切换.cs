using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 场景切换 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GhangeScene(int SceneNumber)
    {
        Debug.Log("加载场景");
        SceneManager.LoadScene(SceneNumber);//加载场景，按场景的Number加载
    }
}
