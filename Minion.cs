using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxX;
    public float minX;
    public float speed;
    public float x;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         move();
    }

    void move()
    {
        x = transform.position.x;
        if (transform.position.x >=maxX || transform.position.x <= minX) {
            speed *= -1;
            
        }
        
        if(speed <=0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        Vector3 movement = new Vector3(1, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

    }

    
}
