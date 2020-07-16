using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelToUnlock;
    public GameObject GameObject;
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("碰撞发生(检测到门)");
            //GameObject.Destroy(this.gameObject);
            GameObject.SetActive(true);
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            //游戏暂停
            Time.timeScale = 0;
            Debug.Log("弹出通过页面");

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
