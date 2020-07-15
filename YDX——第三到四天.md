@[TOC](Unity学习——跑酷游戏第三到四天)
# 关卡的解锁设计
在游戏胜利页面这样写
```csharp
PlayerPrefs.SetInt("levelReached", levelToUnlock);
```
关卡选择页面UI  按钮页面
通过存储公共数值的方式判断是不是可以进入这个关卡、第一关是可以进入的所以将值一开始赋值为1；
在每一关赋予相应的值（好像有一点点bug）
```csharp
public class LevelSelect : MonoBehaviour
{
    public Button[] levelbuttons;
    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelbuttons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelbuttons[i].interactable = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```

# 使游戏物体可以左右移动
代码思路：
设置游戏物体的速度，在超过规定左右移动的范围的时候，将速度变成其相反值便可以了。

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMove : MonoBehaviour
{
    public float speed = 3;
    public float left = -5;
    public float right = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        if (transform.position.x >= right || transform.position.x <= left)
        {
            speed = -speed;
        }
    }
}

```

# 尖刺的设计
在阿里图标库找到图片，做成尖刺。如果游戏物体于其发生碰撞事件，调用游戏结束的函数。
# 发射子弹的炮台的设计
获取要发射的游戏物体，给予其向左的初速，作为子弹，子弹（rigid body组件重力可以去掉），
将子弹的预制体拖在代码公共部分。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200715212935887.png)

```csharp
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

```
# 海绵的设计
给物体一个向上的速度。

```csharp
public float movespeed = 5.0f;//角色踩在海面上之后的速度；
float blastmovespeed;
```

```csharp
if (collision.gameObject.tag == "haimian")
        {
            Debug.Log("检测到海绵");
            blastmovespeed = movespeed * 2.0f;
            Vector3 sudu = new Vector3(0, blastmovespeed, 0);
            Playerrigidbody.velocity = sudu;
        }
```

# 关卡图片
**第三关**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200715213132133.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)
**第四关**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200715213145284.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)