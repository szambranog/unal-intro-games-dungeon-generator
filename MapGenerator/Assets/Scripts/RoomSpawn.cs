using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    private int openSide;

    // 0 Null
    // 1 Left
    // 2 Bottom
    // 3 Top
    private RoomTemplates templates;
    private Main main;
    private int rand;
    private bool Spawned = false;

    void Start()
    {
        main= GameObject.FindGameObjectWithTag("spot").GetComponent<Main>();
        openSide=main.room(gameObject);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        
        Invoke("Spawn",0.1f);
    }

    void Spawn()
    {
        if (Spawned == false)
        {
            rand = Random.Range(0, 2);
            if (openSide == 0)
            {
                // Need Null
                
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }

            if (openSide == 1)
            {
                // Need RightLeft
                
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }

            if (openSide == 2)
            {
                // Need Bottom
                
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }

            if (openSide == 3)
            {
                // Need Top

                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            Spawned = true;
        }
        
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}
