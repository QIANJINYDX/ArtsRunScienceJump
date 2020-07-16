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
