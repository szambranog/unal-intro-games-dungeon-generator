using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private int direction;
    private bool stopGeneration;
    private int currentX;
    private int currentY;
    private int x;
    private int y;
    private int j;
    private string z;
    private string w;
    
    public int[,] matriz = new int[4, 4] {{ 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
    public int[] matr = new int[4] { 0, 0, 0, 0 };

    private void start()    
    {
        room(gameObject);
    }

    public int room(GameObject c)
    {
        currentX = Random.Range(0, 4);
        currentY = 0;
        direction = Random.Range(1, 6);
        while (stopGeneration == false)
        {
            if (direction == 1 || direction == 2)
            { // Move right
                if (currentX < 3)
                {
                    matriz[currentY, currentX] = 1;
                    currentX = currentX + 1;
                    direction = Random.Range(3, 6);
                    if (direction == 3)
                    {
                        direction = 1;
                    }
                    else if (direction == 4)
                    {
                        direction = 2;
                    }
                }
                else
                {
                    direction = 5;
                }
            }
            else if (direction == 3 || direction == 4)
            { // Move left
                if (currentX > 0)
                {
                    matriz[currentY, currentX] = 1;
                    currentX = currentX - 1;

                    direction = Random.Range(3, 6);
                }
                else
                {
                    direction = 5;
                }

            }
            else if (direction == 5)
            { // MoveDown
                matriz[currentY, currentX] = 2;
                currentY++;
                if (currentY < 4)
                {
                    matriz[currentY, currentX] = 3;
                    if (currentX == 3)
                    {
                        currentX = currentX - 1;
                        direction = 3;
                    }
                    else if (currentX == 0)
                    {
                        currentX = currentX + 1;
                        direction = 1;
                    }
                    else
                    {
                        direction = Random.Range(1, 5);
                        if (direction == 1 || direction == 2)
                        {
                            currentX = currentX + 1;
                        }
                        else
                        {
                            currentX = currentX - 1;
                        }
                    }
                }
                else
                {
                    stopGeneration = true;
                }
            }
        }
        z = c.name;
        if (z == "0")
        {
            x = matriz[0, 0];
        }else if (z == "1")
        {
            x = matriz[0, 1];
        }
        else if (z == "2")
        {
            x = matriz[0, 2];
        }
        else if (z == "3")
        {
            x = matriz[0, 3];
        }
        else if (z == "4")
        {
            x = matriz[1, 0];
        }
        else if (z == "5")
        {
            x = matriz[1, 1];
        }
        else if (z == "6")
        {
            x = matriz[1, 2];
        }
        else if (z == "7")
        {
            x = matriz[1, 3];
        }
        else if (z == "8")
        {
            x = matriz[2, 0];
        }
        else if (z == "9")
        {
            x = matriz[2, 1];
        }
        else if (z == "10")
        {
            x = matriz[2, 2];
        }
        else if (z == "11")
        {
            x = matriz[2, 3];
        }
        else if (z == "12")
        {
            x = matriz[3, 0];
        }
        else if (z == "13")
        {
            x = matriz[3, 1];
        }
        else if (z == "14")
        {
            x = matriz[3, 2];
        }
        else if (z == "15")
        {
            x = matriz[3, 3];
        }else if (z == "16")
        {
            j = matriz[0, 0];
            if (j > 0)
            {
                y = y + 1;
            }
            if (y == 1&&j>0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }
        else if (z == "17")
        {
            j = matriz[0, 1];
            if (j > 0)
            {
                y = y + 1;
            }
            if (y == 1&&j>0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }
        else if (z == "18")
        {
            j = matriz[0, 2];
            if (j > 0)
            {
                y = y + 1;
            }
            if (y == 1&&j>0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }
        else if (z == "19")
        {
            j = matriz[0, 3];
            if (j > 0)
            {
                y = y + 1;
            }
            if (y == 1&&j>0)
            {
                x = 1;
            }
            else
            {
                x = 0;
            }
        }
        return x;
    }

}
