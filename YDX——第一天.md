@[TOC](Unity学习——跑酷游戏第一天)
# 1、UI设计
先采用简单的方形进行设计后期在寻找好看的UI
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200711221822468.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)
可滑动列表
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200711221909948.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)
# 2、设计第一个游戏场景
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020071122195875.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

# 3、代码组成
## 场景的切换
在button组件上挂载脚本
并且设置：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200711222207831.png)

```csharp
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
        SceneManager.LoadScene(SceneNumber);//加载场景，按场景的Number加载
    }
}
```
## 可以滑动列表的代码



```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Myscrollguanqia : MonoBehaviour,IBeginDragHandler,IEndDragHandler
{
    private ScrollRect scrollrect;//存放滚动组件
    private float[] pageArray = new float[] { 0, 0.33333f, 0.66666f, 1 };//存放页数的数值
    public Toggle[] toggleArray;//对应页数的下面的选择
    private float targetHorizontailPosition=0;//用来控制页数
    public float smoothing = 4;//回复正常的速度
    private bool isDraging = false;//判断是否拖动
    public void OnBeginDrag(PointerEventData eventData)//开始拖动
    {
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)//拖动结束
    {
        isDraging = false;
        float posX = scrollrect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(pageArray[index] - posX);//默认第一页为最近
        for(int i=1;i<pageArray.Length;i++)
        {
            float offsetTemp = Mathf.Abs(pageArray[i] - posX);//通过绝对值比较最近的是哪一个点
            if(offsetTemp<offset)
            {
                index = i;
                offset = offsetTemp;
            }
        }
        targetHorizontailPosition = pageArray[index];
        toggleArray[index].isOn = true;
        //scrollrect.horizontalNormalizedPosition = pageArray[index];
        print(posX);//输出位置
    }

    // Start is called before the first frame update
    void Start()
    {
        scrollrect = GetComponent<ScrollRect>();
        scrollrect.horizontalNormalizedPosition = 0;
        //初始化位置
        targetHorizontailPosition = pageArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(isDraging==false)
        scrollrect.horizontalNormalizedPosition = Mathf.Lerp(scrollrect.horizontalNormalizedPosition, targetHorizontailPosition, Time.deltaTime*smoothing);//通过Lerp缓慢变化数值，防止突变
    }
    public void MoveToPage1(bool isOn)//绑定Toggle的点击事件
    {
        if (isOn)
        {
            targetHorizontailPosition = pageArray[0];
        }
    }
    public void MoveToPage2(bool isOn)
    {
        if (isOn)
        {
            targetHorizontailPosition = pageArray[1];
        }
    }
    public void MoveToPage3(bool isOn)
    {
        if (isOn)
        {
            targetHorizontailPosition = pageArray[2];
        }
    }
    public void MoveToPage4(bool isOn)
    {
        if (isOn)
        {
            targetHorizontailPosition = pageArray[3];
        }
    }
}

```

## 角色的代码

```csharp
using System.Collections;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody Playerrigidbody;//获得游戏物体的Rigibody组件
    private Transform Transform;//获取游戏物体的Transform组件
    public int speed = 5;
    private bool isJump = false;
    public int jumpForce=4;
    private bool ischangge=false;
    Vector3 vector;
    public float scale = 0.02f;
    Vector3 jumpppppp = new Vector3(0, 5, 0);
    //碰撞检测
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
        //防止物体旋转
        Transform.GetComponent<Rigidbody>().freezeRotation = true;
        //transform.GetComponent<Rigidbody>().freezeRotation = true;

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
        //销毁游戏物体，减小内存消耗
        if (Transform.position.y <= -100)
        {
            GameObject.Destroy(gameObject, 2.0f);
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
    }
}

```