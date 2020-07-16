using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 5.0f;//角色踩在海面上之后的速度；
    float blastmovespeed;
    static int dealmany = 0;//记录死亡的总次数
    public GameObject GameObject;
    public int SceneNumber;
    private Rigidbody Playerrigidbody;//获得游戏物体的Rigibody组件
    private Transform Transform;//获取游戏物体的Transform组件
    public int speed = 5;//物体的移动速度
    private bool isJump = false;
    public int jumpForce=4;
    private bool ischangge=false;
    Vector3 vector;//控制移动方向的向量
    public float scale = 0.02f;
    private float time;//场景加载的时间
    private string time2;//字符型
    public Text time_text;//游戏进行的时间
    public Text time_text2;//在获胜面板显示游戏获胜的时间；
    public Text time_text3;//显示总的死亡次数；
    Vector3 jumpppppp = new Vector3(0, 5, 0);
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("检测到地面");
            isJump = true;
        }
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("检测到门");
            //isJump = true;
        }
        if(collision.gameObject.tag == "jianci")
        {
            Debug.Log("检查到尖刺");
            gameover();
        }
        if (collision.gameObject.tag == "zidan")
        {
            Debug.Log("检测到子弹");

        }
        if (collision.gameObject.tag == "haimian")
        {
            Debug.Log("检测到海绵");
            blastmovespeed = movespeed * 2.0f;
            Vector3 sudu = new Vector3(0, blastmovespeed, 0);
            Playerrigidbody.velocity = sudu;
        }
    }
    private void OnCollisionEnter(Collider collision)
    {
        
    }
    void Start()
    {
        Playerrigidbody = gameObject.GetComponent<Rigidbody>();
        Transform = gameObject.GetComponent<Transform>();
        Vector3 vector = transform.localScale;
        Debug.Log(vector.x);
        time_text3.text = dealmany.ToString();
        Time.timeScale = 1;
        //防止物体旋转
        Transform.GetComponent<Rigidbody>().freezeRotation = true;
        //transform.GetComponent<Rigidbody>().freezeRotation = true;
        //gameObject.GetComponent<Material>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        //左右移动
        if (Input.GetKey(KeyCode.A))
        {
            Playerrigidbody.MovePosition(Playerrigidbody.position + Vector3.left * speed * Time.deltaTime);
            Debug.Log("left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Playerrigidbody.MovePosition(Playerrigidbody.position + Vector3.right * speed * Time.deltaTime);
            Debug.Log("right");
        }
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isJump == true)
        {
            Debug.Log("jumpstart");
            //Playerrigidbody.AddForce(new Vector3(0, jumpForce,0));
            Playerrigidbody.AddForce(new Vector3(0, jumpForce*50, 0));
            Debug.Log("jumpend");
            isJump = false;
        }
        //判断是否可以变化
        if(vector.x>=0&&vector.y>=0)
        {
            ischangge = true;
        }
        //销毁游戏物体
        if (Transform.position.y <= -10)
        {
            gameover();   
        }


        if (Input.GetKey(KeyCode.U)&& ischangge)//x轴变大
        {
            Debug.Log("U");
            transform.localScale += new Vector3(1 * scale, 0, 0);
            ischangge = false;
        }


        if (Input.GetKey(KeyCode.I)&& ischangge)//y轴变大
        {
            Debug.Log("I");
            transform.localScale += new Vector3(0, 1 * scale, 0);
            ischangge = false;
        }


        if (Input.GetKey(KeyCode.J)&& ischangge)//x轴变小
        {
            Debug.Log("J");
            transform.localScale -= new Vector3(1 * scale, 0, 0);
            ischangge = false;
        }


        if (Input.GetKey(KeyCode.K)&& ischangge)//y轴变小
        {
            Debug.Log("K");
            transform.localScale -= new Vector3(0, 1 * scale, 0);
            ischangge = false;
        }
        if(Input.GetKey(KeyCode.O ) && ischangge)
        {
            Debug.Log("O");
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        time = Time.timeSinceLevelLoad;
        //Debug.Log(time);
        if(Time.timeScale!=0)
        {
            time2 = string.Format("{0:F}", time);
            //Debug.Log(time2);
            time_text.text = time2;
            time_text2.text = time2;
        }
        
    }
    void gameover()
    {
        gameObject.SetActive(false);
        GameObject.Destroy(gameObject, 1.0f);
        Time.timeScale = 0;
        GameObject.SetActive(true);
        dealmany++;
        PlayerPrefs.SetInt("dealmany", dealmany);
        Debug.Log(dealmany);
        time_text3.text = dealmany.ToString();
    }
}
