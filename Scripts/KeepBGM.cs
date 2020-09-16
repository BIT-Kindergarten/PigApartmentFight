//保持初始界面和最终界面切换时BGM不停止
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBGM : MonoBehaviour
{
    public GameObject obje;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("BGM1");
        if (obj == null)//如果没有找到BGM1
        {
            obj = GameObject.FindGameObjectWithTag("BGM2");//如果两个BGM都没有找到则加载BGM，只要有一个找到了则不加载，防止多次BGM出现
            if(obj == null)
                obj = (GameObject)Instantiate(obje);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
