using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Space M_rotatespace;
    //旋转速度
    public float M_rotatespeed=100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * M_rotatespeed * Time.deltaTime, M_rotatespace);
    }
}
