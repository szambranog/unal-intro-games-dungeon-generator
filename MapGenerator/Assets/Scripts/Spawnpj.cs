using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpj : MonoBehaviour
{
    private int openSide;
    public int tagg;
    private Vector3 vacio = new Vector3(0, 0, 0);

    private Main main;

    void Start()
    {
        main = GameObject.FindGameObjectWithTag("spot").GetComponent<Main>();
        openSide = main.room(gameObject);
        if (gameObject.name=="16")
        {
            tagg = 1;
        }else if (gameObject.name == "17")
        {
            tagg = 2;
        }else if (gameObject.name == "18")
        {
            tagg = 3;
        }else if (gameObject.name == "19")
        {
            tagg = 4;
        }
    }

    public Vector3 spawnpj()
    {
        if (openSide == 1)
        {
            Debug.Log(gameObject.name);
            return gameObject.transform.position;
            
        }
        else
        {
            return vacio;
        }
        
    }
}
