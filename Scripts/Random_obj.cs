using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_obj : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    //public GameObject GrassObj;
    // Start is called before the first frame update
    void Start()
    {
        int num = 30;
        for (int i = 0; i < num; i++)
        {
            //第一个参数是实例化对象，可定义一个public 的gameobject 对象，第二个参数是vector空间坐标，最后一个参数是旋转方式，这里是不旋转。
            Instantiate(obj1, new Vector3(Random.Range(20f, 180f), 0, Random.Range(20f, 180f)), Quaternion.identity);
            Instantiate(obj2, new Vector3(Random.Range(20f, 180f), 0, Random.Range(20f, 180f)), Quaternion.identity);
            Instantiate(obj3, new Vector3(Random.Range(20f, 180f), 0, Random.Range(20f, 180f)), Quaternion.identity);
            Instantiate(obj4, new Vector3(Random.Range(20f, 180f), 0, Random.Range(20f, 180f)), Quaternion.identity);
            Instantiate(obj5, new Vector3(Random.Range(20f, 180f), 0, Random.Range(20f, 180f)), Quaternion.identity);

        }
        // 草地
        //for (int i = 0; i < 1000; i++)
        //{
        //    //第一个参数是实例化对象，可定义一个public 的gameobject 对象，第二个参数是vector空间坐标，最后一个参数是旋转方式，这里是不旋转。
        //    Instantiate(GrassObj, new Vector3(Random.Range(-40f, 40f), 1, Random.Range(-40f, 40f)), Quaternion.identity);

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
