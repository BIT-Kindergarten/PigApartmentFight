using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitial : MonoBehaviour
{
    public int enemynumber;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("enemy", enemynumber);//初始化记录敌人数量
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
