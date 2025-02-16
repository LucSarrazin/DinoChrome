using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject[] cactus;
    public GameObject[] cactusBig;
    public GameObject bird;

    public float BirdTime;
    public float BirdRepeatRate;

    public float Bird2Time;
    public float Bird2RepeatRate;
    
    
    public float cactusTime;
    public float cactusRepeatRate;  
    
      
    public float cactusBigTime;
    public float cactusBigRepeatRate;


    public movement player;

    public bool OneTime = false;
    
    // Start is called before the first frame update
    void Start()
    {
      

    }

    void StartGame()
    {
        InvokeRepeating("SpawnBird", BirdTime, BirdRepeatRate);
        InvokeRepeating("SpawnBird2", Bird2Time, Bird2RepeatRate);
        InvokeRepeating("SpawnCactus", cactusTime, cactusRepeatRate);
        InvokeRepeating("SpawnBigCactus", cactusBigTime, cactusBigRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        Bird2RepeatRate = Bird2RepeatRate + Time.deltaTime;
        BirdRepeatRate = BirdRepeatRate + Time.deltaTime;
        cactusRepeatRate = cactusRepeatRate + Time.deltaTime;
        cactusBigRepeatRate = cactusBigRepeatRate + Time.deltaTime;
            
        if (player.GameOver == true)
        {
            CancelInvoke();
            OneTime = false;
        }
        else
        {
            if (!OneTime)
            {
                StartGame();
                OneTime = true;
            }
        }
    }

    public void SpawnCactus()
    {
        Instantiate(cactus[Random.Range(0,2)], new Vector2(14,-2.549368f), Quaternion.identity);
    }

    public void SpawnBigCactus()
    {
        Instantiate(cactusBig[Random.Range(0,2)], new Vector2(14,-2.277f), Quaternion.identity);
    }

    public void SpawnBird()
    {
        Instantiate(bird, new Vector2(14f, -1.98f), Quaternion.identity);
    }
    public void SpawnBird2()
    {
        Instantiate(bird, new Vector2(14f, -0.72f), Quaternion.identity);
    }
}
