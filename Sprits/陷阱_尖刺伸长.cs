using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 陷阱_尖刺伸长 : MonoBehaviour
{
    public GameObject jianci;
    int i = 0;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"&&i<1)
        {
            Debug.Log("角色触碰陷阱（尖刺伸长术）");
            jianci.transform.localScale += new Vector3(0, 1, 0);
            jianci.transform.position += new Vector3(0, 0.5f, 0);
            i++;
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
