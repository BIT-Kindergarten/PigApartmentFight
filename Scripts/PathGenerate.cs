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

    bool[,] pots = new bool[200,200];  // 记录路径占用的点
    int[,] pcubes = new int[2,1000];    // 顺序存储路径坐标
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
        pcubes[0, lenpots] = x;
        pcubes[1, lenpots] = y;
        lenpots += 1;
    }

    // 判断(a,b)与(x,y)距离是否足够 d 远
    private bool isFar(float a, float b, float x, float y, float d)
    {
        return ((a - x) * (a - x) + (b - y) * (b - y)) >= d * d ? true : false;
    }

    // 道路两边生成树、石头等场景元素
    private void GenerateTree()
    {
        //for (int i = 0; i < environ_num; i++)
        //{
        //    int tx = Random.Range(x - 20, x + 20);
        //    int ty = Random.Range(y - 20, y + 20);
        //    if (isFar(tx, ty, x1, y1, 10) && isFar(tx, ty, x, y, 4) && pots[tx,ty] )
        //    {
        //        Instantiate(trees[Random.Range(0,3)], new Vector3(tx, 0, ty), Quaternion.identity);
        //    }
        //}
        for (int i = 0; i<lenpots;i++)
        {
            x = pcubes[0, i];
            y = pcubes[1, i];
            for(int j = 0; j<environ_num; j++)
            {
                int tx = Random.Range(x - 20, x + 20);
                int ty = Random.Range(y - 20, y + 20);
                if (isFar(tx, ty, x1, y1, 10) && isFar(tx, ty, x2, y2, 8) && pots[tx, ty])
                {
                    Instantiate(trees[Random.Range(0, 3)], new Vector3(tx, 0, ty), Quaternion.identity);
                }
            }
        }
    }

    private void GeneratePathNW(int enx, int eny)       // North West ↖
    {
        //while( isFar(x,y,enx,eny,10) )
        //while ((xreal <= eny) || (yreal >= enx))  // x、y依次到达一次停止
        while ((yreal <= eny) || (xreal <= enx))  // x、y依次到达一次停止
        {
            //Debug.log("x,y :   "+x+" , "+ y);
            if (temp == 1)
            {
                j = Random.Range(8, 12);    // 步长，每次改变方向之后路径的直线段长度，几个cube
                if (mask == 0)  // 未超过，一直往对角走
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y + i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        //GenerateTree(a, b); // 每走一步生成tree
                    }
                    //temp = 2;
                    y = y + j;
                    if (yreal <= eny) //  yreal最终超越边界
                        yreal = y;
                    if (x < enx)
                        mask = 0;
                    else
                        mask = 1;
                }
                else  // mask=1，超越边界之后往反方向走
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y - i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        //GenerateTree(a, b);
                    }
                    //temp = 2;
                    y = y - j;
                    mask = 0;
                }
                temp = 2;
            }
            else if (temp == 2)
            {
                j = Random.Range(8, 12);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x + i, b = y;
                        Instantiate(Pobj, new Vector3( a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        //GenerateTree(a, b);
                    }
                    //temp = 1;
                    x = x + j;
                    if (xreal <= enx)
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
                        int a = x - i, b = y;
                        Instantiate(Pobj, new Vector3( a, 0, b), Quaternion.identity);
                        addpots(a, b);
                        //GenerateTree(a, b);
                    }
                    //temp = 1;
                    x = x - j;
                    mask = 0;
                }
                temp = 1;
            }
            else
                break;
            Debug.Log("temp,mask:  "+temp+" , "+mask+",  path1_x,y :   " + x + " , " + y);
        }
    }

    // 每条路重用GeneratePath可能会出现问题
    // 目前的解决方法是重写一条，成功运行得到想要的效果之后再看能不能整合
    private void GeneratePathNE(int enx, int eny) // ↗North East
    {
        while ((xreal <= enx) || (yreal >= eny))
        {
            if (temp == 1)
            {
                j = Random.Range(8, 12);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y - i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a,b);
                    }
                    temp = 2;
                    y = y - j;
                    if (yreal >= eny)
                        yreal = y;
                    if (x > enx) // 越界，反方向走
                    {
                        mask = 1;
                    }
                    else
                    {
                        mask = 0;
                    }
                    // mask = x>enx?1:0;   //???
                }
                else  // temp   1,   mask   1
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y + i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 2;
                    y = y + j;
                    mask = 0;
                }
            }
            else if (temp == 2)
            {
                j = Random.Range(8, 12);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x + i, b = y;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 1;
                    x = x + j;

                    if (xreal <= enx)
                        xreal = x;
                    mask = y < eny ? 1 : 0;
                    //if (y < eny)
                    //{
                    //    mask = 1;
                    //}
                    //else  
                    //{
                    //    mask = 0;
                    //}
                }
                else // temp 2, mask  1
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x - i, b = y;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 1;
                    x = x - j;
                    mask = 0;
                }
            }
            else
                break;
            Debug.Log("temp,mask:  " + temp + " , " + mask + ",  path2_x,y :   " + x + " , " + y);
        }
    }

    private void GeneratePathSW(int enx, int eny) // ↙South West
    {
        while ((xreal >= enx) || (yreal <= eny))
        {
            if (temp == 1)
            {
                j = Random.Range(8, 12);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y + i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 2;
                    y = y + j;
                    if (yreal <= eny)
                        yreal = y;
                    if (x < enx) // 越界，反方向走
                    {
                        mask = 1;
                    }
                    else
                    {
                        mask = 0;
                    }
                    // mask = x>enx?1:0;   //???
                }
                else  // temp   1,   mask   1
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x, b = y - i;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 2;
                    y = y - j;
                    mask = 0;
                }
            }
            else if (temp == 2)
            {
                j = Random.Range(8, 12);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x - i, b = y;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 1;
                    x = x - j;

                    if (xreal >= enx)
                        xreal = x;

                    mask = y > eny ? 1 : 0;

                }
                else // temp 2, mask  1
                {
                    for (int i = 0; i < j; i++)
                    {
                        int a = x + i, b = y;
                        Instantiate(Pobj, new Vector3(a, 0, b), Quaternion.identity);
                        addpots(a, b);
                    }
                    temp = 1;
                    x = x + j;
                    mask = 0;
                }
            }
            else
                break;
            Debug.Log("temp,mask:  " + temp + " , " + mask + ",  path2_x,y :   " + x + " , " + y);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initpots(); // 初始化数组，每个点可放道具

        x = 40;// 初始点位置
        y = 40;// y实际是z

        temp = Random.Range(1, 3);  //主要方向

        //x1 = Random.Range(50, 90);//  怪物位置
        //y1 = Random.Range(120, 160);
        //Instantiate(ene1, new Vector3(x1, 0, y1), Quaternion.identity); // 生成怪物
        //x2 = Random.Range(100, 160);//  怪物位置
        //y2 = Random.Range(40, 100);
        //Instantiate(ene2, new Vector3(x2, 0, y2), Quaternion.identity); // 生成怪物

        //x2 = Random.Range(-50, -29);
        //y2 = Random.Range(30, 40);

        // 随机选择 生成路径
        int rp;
        //rp = 0;
        //rp = 1;
        rp = Random.Range(0, 2);   // 两种  ↖↗↖，↖↙↖ 

        if (rp == 0)
        {
            x1 = Random.Range(50, 90);//  怪物位置
            y1 = Random.Range(120, 160);
            Instantiate(ene1, new Vector3(x1, 0, y1), Quaternion.identity); // 生成怪物
            x2 = Random.Range(100, 160);//  怪物位置
            y2 = Random.Range(40, 100);
            Instantiate(ene2, new Vector3(x2, 0, y2), Quaternion.identity); // 生成怪物

            GeneratePathNW(x1, y1);
            Debug.Log("xreal,yreal :   " + xreal + " , " + yreal);
            GeneratePathNE(x2, y2);
            Debug.Log("xreal,yreal :   " + xreal + " , " + yreal);
            GeneratePathNW(160, 160);
            Debug.Log("xreal,yreal :   " + xreal + " , " + yreal);
        }
        else if(rp == 1)
        {
            x1 = Random.Range(100, 160);//  怪物位置
            y1 = Random.Range(40, 100);
            Instantiate(ene1, new Vector3(x1, 0, y1), Quaternion.identity); // 生成怪物
            x2 = Random.Range(50, 90);//  怪物位置
            y2 = Random.Range(120, 160);
            Instantiate(ene2, new Vector3(x2, 0, y2), Quaternion.identity); // 生成怪物

            GeneratePathNW(x1, y1);
            Debug.Log("xreal,yreal :   " + xreal + " , " + yreal);
            GeneratePathSW(x2, y2);
            Debug.Log("xreal,yreal :   " + xreal + " , " + yreal);
            GeneratePathNW(160, 160);
            Debug.Log("xreal,yreal :   " + xreal + " , " + yreal);
        }
        else
        {
            Debug.Log("rp should be in {0,1}");   
        }
            
        Debug.Log("怪物位置 :   " + x1 + " , " + y1 + "    第二个, " + x2 + "," + y2);
        

        //int Cx = 100;
        //int Cy = 100;
        //// if (Cx!=x)
        //x += abs(Cx - x1) / (Cx - x) * (50 - 40);
        //y += abs(Cy - y1) / (Cy - y) * (175 - 160);

        if(plant)
            GenerateTree();

        Debug.Log("Lenpots : " + lenpots);
    }

    // Update is called once per frame
    void Update()
    {

    }
}