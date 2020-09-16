//初始化用户数据，利用playerprefs存储四个变量
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("attack", 20);
        PlayerPrefs.SetInt("maxHealth", 100);
        PlayerPrefs.SetInt("atspeed", 1);
        PlayerPrefs.SetInt("armor", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
