using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerate : MonoBehaviour
{
    public GameObject Pobj;
    public GameObject ene1;
    public GameObject ene2;

    //每走一步，一个cube，生成的环境素材和数量
    public bool plant = false;
    int environ_num = 1;
    public GameObject environ1;
    public GameObject environ2;
    public GameObject environ3;
    //public GameObject environ1;
    //public GameObject environ1;
    //public GameObject environ1;
    //public GameObject environ1;

    public GameObject[] trees ;

    bool[,] pots = new bool[200,200];
    int lenpots = 0;

    int j, temp, mask = 0;   // mask是否需要转向
    int x, y;

    int xreal = 40; // 到达时的坐标
    int yreal = 40;

    int x1, y1;   // 怪物位置，在此声明以便//GenerateTree中可使用
    int x2, y2;

    private int abs(int a)
    {
        return a > 0 ? a : -a;
    }

    private void initpots()
    {
        trees = new GameObject[] {environ1, environ2, environ3 };

        for(int i= 0; i < 200; i++)
        {
            for(int j = 0; j < 200; j++)
            {
                pots[i, j] = true;
            }
        }
    }

    private void addpots(int x, int y)
    {
        pots[x, y] = false;
        lenpots += 1;
    }

    // 判断(a,b)与(x,y)距离是否足够 d 远
    private bool isFar(float a, float b, float x, float y, float d)
    {
        return ((a - x) * (a - x) + (b - y) * (b - y)) >= d * d ? true : false;
    }

    // 道路两边生成树、石头等场景元素
    private void GenerateTree(int x, int y)
    {
        int limit = 1000;
        for (int i = 0; i < environ_num; i++)
        {
            int tx = Random.Range(x - 20, x + 20);
            int ty = Random.Range(y - 20, y + 20);
            if (isFar(tx, ty, x1, y1, 10) && isFar(tx, ty, x, y, 4) )
            {
                Instantiate(trees[Random.Range(0,3)], new Vector3(tx, 0, ty), Quaternion.identity);
            }
        }
    }

    private void GeneratePath1(int enx, int eny)
    {
        //while( isFar(x,y,enx,eny,10) )
        //while ((xreal <= eny) || (yreal >= enx))  // x、y依次到达一次停止
        while ((yreal <= eny) || (xreal >= enx))  // x、y依次到达一次停止
        {

            if (temp == 1)
            {
                j = Random.Range(5, 10);    // 步长，每次改变方向之后路径的直线段长度，几个cube
                if (mask == 0)  // 不转弯
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y + i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        if(plant) GenerateTree(a, b); // 每走一步生成tree
                    }
                    //temp = 2;
                    y = y + j;
                    if (yreal <= eny)
                        yreal = y;
                    if (x < enx)
                        mask = 1;
                    else
                        mask = 0;
                }
                else  // mask=1
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y - i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        if(plant) GenerateTree(a, b);
                    }
                    //temp = 2;
                    y = y - j;

                    mask = 0;
                }
                temp = 2;
            }
            else if (temp == 2)
            {
                j = Random.Range(5, 10);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x - i, b = y;
                        Instantiate(Pobj, new Vector3( a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        
                        if(plant) GenerateTree(a, b);
                    }
                    temp = 1;
                    x = x - j;
                    if (xreal >= enx)
                        xreal = x;
                    if (y <= eny)
                        mask = 0;
                    else
                        mask = 1;
                }
                else // temp  =2 , mask = 1;
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x + i, b = y;
                        Instantiate(Pobj, new Vector3( a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        if(plant) GenerateTree(a, b);
                    }
                    temp = 1;
                    x = x + j;
                    mask = 0;
                }

            }
            else
                break;
        }
    }

    //private void GeneratePath2()
    //{
    //    while ((xreal <= y2) || (yreal <= x2))
    //    {

    //        if (temp == 1)
    //        {
    //            j = Random.Range(5, 10);
    //            if (mask == 0)
    //            {
    //                for (int i = 0; i < j; i++)

    //                {

    //                    Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


    //                }
    //                temp = 2;
    //                x = x + j;
    //                x = x + 1;
    //                if (xreal <= y2)
    //                    xreal = x;
    //                if (y > x2)
    //                {
    //                    mask = 1;
    //                    y = y + 1;
    //                }

    //                else
    //                {
    //                    mask = 0;
    //                    y = y - 1;
    //                }
    //            }
    //            else
    //            {
    //                for (int i = 0; i < j; i++)

    //                {

    //                    Instantiate(obj, new Vector3(y, 0, x - i), Quaternion.identity);


    //                }
    //                temp = 2;
    //                x = x - j;
    //                y = y - 1;
    //                x = x - 1;

    //                mask = 0;

    //            }


    //        }
    //        else if (temp == 2)
    //        {

    //            j = Random.Range(5, 10);
    //            if (mask == 0)
    //            {
    //                for (int i = 0; i < j; i++)
    //                {
    //                    Instantiate(obj1, new Vector3(y + i, 0, x), Quaternion.identity);
    //                }
    //                temp = 1;
    //                y = y + j;
    //                y = y + 1;

    //                if (yreal <= x2)
    //                    yreal = y;
    //                if (x <= y2)
    //                {
    //                    mask = 0;
    //                    x = x - 1;
    //                }
    //                else
    //                {
    //                    mask = 1;
    //                    x = x + 1;
    //                }
    //            }
    //            else
    //            {
    //                for (int i = 0; i < j; i++)
    //                {
    //                    Instantiate(obj1, new Vector3(y - i, 0, x), Quaternion.identity);
    //                }
    //                temp = 1;
    //                y = y - j;
    //                y = y - 1;
    //                x = x - 1;
    //                mask = 0;
    //            }

    //        }
    //        else
    //            break;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        initpots(); // 初始化数组，每个点可放道具

        x = 40;// 初始点位置
        y = 40;// y实际是z

        temp = Random.Range(1, 3);  //方向

        x1 = Random.Range(40, 100);//  怪物位置
        y1 = Random.Range(100, 160);
        Instantiate(ene1, new Vector3(x1, 0, y1), Quaternion.identity); // 生成怪物
        x2 = Random.Range(100, 160);//  怪物位置
        y2 = Random.Range(40, 100);
        Instantiate(ene2, new Vector3(x2, 0, y2), Quaternion.identity); // 生成怪物

        //x2 = Random.Range(-50, -29);
        //y2 = Random.Range(30, 40);

        GeneratePath1(x1, y1);

        //int Cx = 100;
        //int Cy = 100;
        //// if (Cx!=x)
        //x += abs(Cx - x1) / (Cx - x) * (50 - 40);
        //y += abs(Cy - y1) / (Cy - y) * (175 - 160);

        //GeneratePath(x2, y2);

    }

    // Update is called once per frame
    void Update()
    {

    }
}