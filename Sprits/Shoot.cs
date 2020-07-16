using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int Speed = 20;
    public Rigidbody Bullet;
    public Transform FPonit;
    public float shootSpeed = 2;
    private float shootTimer = 0;
    private float shootTimerInterval = 0;
    // Start is called before the first frame update
    void Start()
    {
        shootTimerInterval = 1 / shootSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer > shootTimerInterval)
        {
            shootTimer -= shootTimerInterval;
            shoot();
        }
    }
    void shoot()
    {
        Rigidbody clone;
        clone = (Rigidbody)Instantiate(Bullet, FPonit.position, FPonit.rotation);
        clone.velocity = transform.TransformDirection(Vector3.right * Speed);
    }
}
