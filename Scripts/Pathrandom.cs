using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathrandom : MonoBehaviour
{
    public GameObject obj;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;

    //每走一步，一个cube，生成的环境素材和数量




    void Start()
    {
        int j, temp, mask = 0;
        int x, y;
        int symbol;
        int xreal = 36;
        int yreal = 78;
        int x1, y1;
        int x2, y2;
        x = 36;
        y = 78;
        temp = Random.Range(1, 3);
        symbol = Random.Range(1, 3); 

        x1 = Random.Range(-30, -10);
        y1 = Random.Range(80, 100);
        Instantiate(obj2, new Vector3(x1, 0, y1), Quaternion.identity);
        Instantiate(obj3, new Vector3(x1, 5, y1-2), Quaternion.identity);
        Instantiate(obj4, new Vector3(x1, 17, y1- 2), Quaternion.identity);
        x2 = Random.Range(79, 82);
        y2 = Random.Range(130, 150);
        Instantiate(obj2, new Vector3(x2, 0, y2), Quaternion.identity);
        Instantiate(obj3, new Vector3(x2, 5, y2+2), Quaternion.identity);
        Instantiate(obj4, new Vector3(x2, 17, y2 + 2), Quaternion.identity);
        if (symbol == 1)
        {
            while ((xreal <= y1) || (yreal >= x1))
            {
                if (temp == 1)
                {
                    j = Random.Range(5, 10);
                    if (mask == 0)
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x + j;
                        x = x + 1;
                        y = y + 1;

                        if (xreal <= y1)
                            xreal = x;
                        if (y < x1)
                            mask = 1;
                        else
                            mask = 0;

                    }
                    else
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x - i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x - j;
                        y = y + 1;
                        x = x - 1;

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
                            Instantiate(obj1, new Vector3(y - i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y - j;
                        y = y - 1;

                        if (yreal >= x1)
                            yreal = y;
                        if (x <= y1)
                        {
                            mask = 0;
                            x = x - 1;
                        }
                        else
                        {
                            mask = 1;
                            x = x + 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < j; i++)
                        {
                            Instantiate(obj1, new Vector3(y + i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y + j;
                        y = y + 1;
                        x = x - 1;
                        mask = 0;
                    }

                }
                else
                    break;
            }


            while ((xreal <= y2) || (yreal <= x2))
            {

                if (temp == 1)
                {
                    j = Random.Range(5, 10);
                    if (mask == 0)
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x + j;
                        x = x + 1;
                        if (xreal <= y2)
                            xreal = x;
                        if (y > x2)
                        {
                            mask = 1;
                            y = y + 1;
                        }

                        else
                        {
                            mask = 0;
                            y = y - 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x - i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x - j;
                        y = y - 1;
                        x = x - 1;

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
                            Instantiate(obj1, new Vector3(y + i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y + j;
                        y = y + 1;

                        if (yreal <= x2)
                            yreal = y;
                        if (x <= y2)
                        {
                            mask = 0;
                            x = x - 1;
                        }
                        else
                        {
                            mask = 1;
                            x = x + 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < j; i++)
                        {
                            Instantiate(obj1, new Vector3(y - i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y - j;
                        y = y - 1;
                        x = x - 1;
                        mask = 0;
                    }

                }
                else
                    break;
            }
            x = x + 7;
            y = y + 2;

            while ((xreal <= 200) || (yreal >= 0))
            {

                if (temp == 1)
                {
                    j = Random.Range(5, 10);
                    for (int i = 0; i < j; i++)

                    {

                        Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                    }
                    temp = 2;
                    x = x + j;
                    y = y + 1;
                    x = x + 1;
                    xreal = x;
                    if (y < 0)
                        temp = 1;



                }
                else if (temp == 2)
                {

                    j = Random.Range(5, 10);
                    {
                        for (int i = 0; i < j; i++)
                        {
                            Instantiate(obj1, new Vector3(y - i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y - j;

                        yreal = y;
                        if (x >= 200)
                        {
                            temp = 2;

                        }
                        else
                        {
                            y = y - 1;
                            x = x - 1;
                        }
                    }


                }
                else
                    break;
            }




        }
        else
        {
            y = 68;
            x = 40;
            xreal = x;
            yreal = y;
            while ((xreal <= y2) || (yreal <= x2))
            {
                if (temp == 1)
                {
                    j = Random.Range(5, 10);
                    if (mask == 0)
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x + j;
                        x = x + 1;
                       

                        if (xreal <= y2)
                            xreal = x;
                        if (y > x2)
                        {
                            mask = 1;
                            y = y + 1;
                        }
                        else
                        {

                            mask = 0;
                            y = y - 1;
                        }

                    }
                    else
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x - j;
                        y = y + 1;
                        x = x - 1;

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
                            Instantiate(obj1, new Vector3(y + i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y + j;
                        y = y + 1;

                        if (yreal <= x2)
                            yreal = y;
                        if (x <= y2)
                        {
                            mask = 0;
                            x = x - 1;
                        }
                        else
                        {
                            mask = 1;
                            x = x + 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < j; i++)
                        {
                            Instantiate(obj1, new Vector3(y - i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y - j;
                        y = y - 1;
                        x = x - 1;
                        mask = 0;
                    }

                }
                else
                    break;
            }

            x = x + 7;
            y = y - 5;
           
            while ((xreal >= y1) || (yreal >= x1))
            {
                if (temp == 1)
                {
                    j = Random.Range(5, 10);
                    if (mask == 0)
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x - i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x - j;
                        x = x - 1;
                        y = y + 1;

                        if (xreal >= y1)
                            xreal = x;
                        if (y < x1)
                            mask = 1;
                        else
                            mask = 0;

                    }
                    else
                    {
                        for (int i = 0; i < j; i++)

                        {

                            Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                        }
                        temp = 2;
                        x = x + j;
                        y = y + 1;
                        x = x + 1;

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
                            Instantiate(obj1, new Vector3(y - i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y - j;
                        y = y - 1;

                        if (yreal >= x1)
                            yreal = y;
                        if (x >= y1)
                        {
                            mask = 0;
                            x = x + 1;
                        }
                        else
                        {
                            mask = 1;
                            x = x - 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < j; i++)
                        {
                            Instantiate(obj1, new Vector3(y + i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y + j;
                        y = y + 1;
                        x = x + 1;
                        mask = 0;
                    }

                }
                else
                    break;
            }

            x = xreal + 5;
            y = yreal + 3;
            while ((xreal <= 200) || (yreal <= 0))
            {

                if (temp == 1)
                {
                    j = Random.Range(5, 10);
                    for (int i = 0; i < j; i++)

                    {

                        Instantiate(obj, new Vector3(y, 0, x + i), Quaternion.identity);


                    }
                    temp = 2;
                    x = x + j;
                    
                    xreal = x;
                    if (y > 0)
                        temp = 1;
                    else
                    {
                        y = y - 1;
                        x = x + 1;
                    }




                }
                else if (temp == 2)
                {

                    j = Random.Range(5, 10);
                    {
                        for (int i = 0; i < j; i++)
                        {
                            Instantiate(obj1, new Vector3(y + i, 0, x), Quaternion.identity);
                        }
                        temp = 1;
                        y = y + j;
                        y = y + 1;
                        x = x - 1;

                        yreal = y;
                        if (x >= 200)
                        {
                            temp = 2;

                        }
                        
                    }


                }
                else
                    break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
