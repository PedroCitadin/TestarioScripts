using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderInimigo : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Destroy(this.gameObject);
                GameControllerlvl2.instance.vidas--;
            }
        }
        else if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
    }

}
