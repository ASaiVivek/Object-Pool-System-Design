//GitHub-vivekboss99-object pool system design
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public int wallPoolSize = 5;
    private GameObject[] walls;

    public float spawnRate = 4f;

    public GameObject[] wallPrefab;

    private Vector3 samplePos = new Vector3(0, -100, 0);
    private float timeSinceSpawned;
    public float spawnZ = 200f;//for spawning the wall in front of the jet
    private int currentWall = 0;
    public GameObject Player;
    public int floatOrigin = 0;
    public int MaxZdistance = 1000;

    //public int spawned = 1;

    bool started;
    GameObject canvas;
    private int HeightPool;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        walls = new GameObject[wallPoolSize];
        for(int i = 0; i < wallPoolSize; i++) //storing the prefabs into array for pooling
        {
            walls[i] = (GameObject)Instantiate(wallPrefab[i], samplePos, Quaternion.identity);
        }
        
        canvas = GameObject.FindGameObjectWithTag("Canvas");


    }
    

    // Update is called once per frame
    void Update()
    {
       // started = canvas.GetComponent<MenuController>().started;
       // if (started == true)
        //{
            //timeSinceSpawned += Time.deltaTime;
            floatOrigin++;

            //original pooling method perfect for constant speed

           // if (timeSinceSpawned >= spawnRate) //write gameover is true or false condition
            //{
              //  timeSinceSpawned = 0;
               // walls[currentWall].transform.position = new Vector3(0, 0, Player.transform.position.z + spawnZ);
               // currentWall++;
               // if (currentWall >= wallPoolSize)
                //{
                //    currentWall = 0;
               // }


                if (floatOrigin >= MaxZdistance)//floating origin currently set by checking a integer value to limit the player distance
                {
                    floatOrigin = 0;
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -90f);
                }
            //}
        }


       //testing pool with trigger object

    public void Spawner()
    {
        HeightPool = Random.Range(-5, 5);//for change in height when spawned
       // Debug.Log("FunctionSpawned");
          walls[currentWall].transform.position = new Vector3(0, HeightPool, Player.transform.position.z + spawnZ);
           
          currentWall++;

          if (currentWall >= wallPoolSize)
          {
              currentWall = 0;
           }
    }
}
