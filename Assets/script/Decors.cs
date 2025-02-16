using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Decors : MonoBehaviour
{
    public float speed;
    private movement player;
    public ParticleSystem explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
    }

    // Update is called once per frame
    void Update()
    {

        speed = speed - Time.deltaTime;
        if (player.GameOver == false)
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GameOver = true;
            Instantiate(explosion, transform.position, new Quaternion(180,0,0,0));
        }

        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
    
    
}
