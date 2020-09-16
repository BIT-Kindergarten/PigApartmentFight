using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerate : MonoBehaviour
{
    public GameObject Pobj;
    public GameObject ene1;
    public GameObject ene2;

    //每走一步，一个cube，生成的环境素材和数量
    int environ_num = 2; 
    public GameObject environ1;
    public GameObject environ2;
    public GameObject environ3;
    //public GameObject environ1;
    //public GameObject environ1;
    //public GameObject environ1;
    //public GameObject environ1;

    int j, temp, mask = 0;   // mask是否需要转向
    int x, y;

    int xreal = 40; // 到达时的坐标
    int yreal = 40;

    int x1, y1;   // 怪物位置，在此声明以便//GenerateTree中可使用
    int x2, y2;

    private int abs(int a )
    {
        return a > 0 ? a : -a;
    }

    // 判断(a,b)与(x,y)距离是否足够 d 远
    private bool isFar(float a, float b, float x, float y, float d)
    {
        return ( (a - x) *(a-x) + (b - y)*(b-y) ) >= d * d ? true : false;
    }

    // 道路两边生成树、石头等场景元素
    private void GenerateTree(int x, int y)
    {
        for (int i = 0; i < environ_num; i++)
        {
            int tx = Random.Range(x - 20, x + 20);
            int ty = Random.Range(y - 20, y + 20);
            if (isFar(tx, ty, x1, y1, 10) && isFar(tx, ty, x, y, 4 ) )
            {
                Instantiate(environ1, new Vector3(tx, 0, ty), Quaternion.identity);
                Instantiate(environ2, new Vector3(tx, 0, ty), Quaternion.identity);
                Instantiate(environ3, new Vector3(tx, 0, ty), Quaternion.identity);
            }
        }
    }

    private void GeneratePath(int enx, int eny)
    {
        //while( isFar(x,y,enx,eny,10) )
        while ((xreal <= eny) || (yreal >= enx))  // x、y依次到达一次停止
        {

            if (temp == 1)
            {
                j = Random.Range(5, 10);    // 步长，每次改变方向之后路径的直线段长度，几个cube
                if (mask == 0)  // 不转弯
                {
                    for (int i = 0; i < j; i++)
                    {
                        Instantiate(Pobj, new Vector3(y, 0, x + i), Quaternion.identity);
                        //GenerateTree(x, y); // 每走一步生成tree
                    }
                    temp = 2;
                    x = x + j;
                    if (xreal <= eny)
                        xreal = x;
                    if (y < enx)
                        mask = 1;
                    else
                        mask = 0;
                }
                else
                {
                    for (int i = 0; i < j; i++)
                    {
                        Instantiate(Pobj, new Vector3(y, 0, x - i), Quaternion.identity);
                        //GenerateTree(x, y);
                    }
                    temp = 2;
                    x = x - j;

                    mask = 0;
                }
            }
            else if (temp == 2)
            {
                j = Random.Range(5, 10);
                if (mask == 0)
                {
                    for (int i = 0; i < j; i++)
                    {
                        Instantiate(Pobj, new Vector3(y - i, 0, x), Quaternion.identity);
                        //GenerateTree(x, y);
                    }
                    temp = 1;
                    y = y - j;
                    if (yreal >= enx)
                        yreal = y;
                    if (x <= eny)
                        mask = 0;
                    else
                        mask = 1;
                }
                else
                {
                    for (int i = 0; i < j; i++)
                    {
                        Instantiate(Pobj, new Vector3(y + i, 0, x), Quaternion.identity);
                        //GenerateTree(x, y);
                    }
                    temp = 1;
                    y = y + j;
                    mask = 0;
                }

            }
            else
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        x = 40;// 初始点位置
        y = 40;// y实际是z
        
        temp = Random.Range(1, 3);  //方向

        x1 = Random.Range(40, 150);//  怪物位置
        y1 = Random.Range(100, 175);
        Instantiate(ene1, new Vector3(x1, 0, y1), Quaternion.identity); // 生成怪物
        x2 = Random.Range(160, 180);//  怪物位置
        y2 = Random.Range(150, 160);
        Instantiate(ene2, new Vector3(x2, 0, y2), Quaternion.identity); // 生成怪物

        //x2 = Random.Range(-50, -29);
        //y2 = Random.Range(30, 40);

        GeneratePath(x1,y1);

        int Cx = 100;
        int Cy = 100;
        // if (Cx!=x)
        x += abs(Cx-x1)/(Cx-x) *(50-40) ;
        y += abs(Cy - y1) / (Cy - y)  * (175 - 160);

        GeneratePath(x2, y2);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
