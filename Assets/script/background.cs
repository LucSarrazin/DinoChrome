using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{

    public int speed;
    private movement player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GameOver == false)
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -41)
            {
                transform.position = new Vector3(41, -3.49f, 0);
            }
        }

    }
}
