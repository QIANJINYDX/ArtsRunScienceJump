using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 陷阱_方块消失 : MonoBehaviour
{
    public GameObject[] GameObject;
    int i = 0;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("角色触碰陷阱（方块消失术）");
            InvokeRepeating("tianjia", 0.1f, 0.1f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void tianjia()
    {
        GameObject[i].AddComponent<Rigidbody>();
        i++;
    }
}
