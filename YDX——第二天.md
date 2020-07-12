@[TOC](Unity学习——跑酷游戏第二天)
# 1、按键弹出返回页面
## 1.1、配置UI画面
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200712094355157.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)
## 1.2、整个UI上挂载Canvas Group组件
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200712094426300.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)
将Alpha的值赋值为0；
**Alpha表示透明度的意思，值为0就是完全透明的意思，相当于隐藏了。**
Interactable钩去掉；
**Interactable是，是不是容许交互的功能，不显示的时候肯定是不能交互的，所以取消√**
## 1.3、挂载脚本
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200712094552364.png)

## 1.4、脚本编写

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC_KK : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameObject;
    void Start()
    {
    //初始化
        GameObject.GetComponent<CanvasGroup>().alpha = 0;
        GameObject.GetComponent<CanvasGroup>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//如果按下ESC键则返回
        {
            GameObject.GetComponent<CanvasGroup>().alpha = 1;
            GameObject.GetComponent<CanvasGroup>().interactable = true;
            Debug.Log("弹出返回页面");
        }
        if (Input.GetKeyDown(KeyCode.P ))//如果按下ESC键则返回
        {
            GameObject.GetComponent<CanvasGroup>().alpha = 0;
            GameObject.GetComponent<CanvasGroup>().interactable = false;
            Debug.Log("弹出返回页面");
        }

    }
}

```
# 2、弹出游戏结束的页面

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200712095003446.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)

## 2.1、与门进行碰撞检测
胜利界面的弹出和返回页面原理相似

```csharp
private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")//与门发生碰撞的物体是Player
        {
            Debug.Log("碰撞发生(检测到门)");
            //GameObject.Destroy(this.gameObject);
            GameObject.GetComponent<CanvasGroup>().alpha = 1;
            GameObject.GetComponent<CanvasGroup>().interactable = true;
            //游戏暂停
            Time.timeScale = 0;
            Debug.Log("弹出通过页面");

        }
    }
```
# 3、显示时间通过时间

## 3.1、设置文本类型UI

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200712224853967.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L2NhaXhpYW9iYWlkZXll,size_16,color_FFFFFF,t_70)
## 3.2、Player脚本设置

```csharp
public Text time_text;
```
再将要显示时间的文本拖上去

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200712224558934.png)
## 3.3、通过代码给text传值

```csharp
 time = Time.timeSinceLevelLoad;
        //Debug.Log(time);
        if(Time.timeScale!=0)//用来判断是否暂停了游戏，如果没有暂停则计时；
        {
            time2 = string.Format("{0:F}", time);//转化为浮点数并保留两位小数
            //Debug.Log(time2);
            time_text.text = time2;//传参给显示的文本
        }
```