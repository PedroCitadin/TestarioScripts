using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Poder : MonoBehaviour
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
        if (SceneManager.GetActiveScene().name == "lvl_1")
        {

            if (collision.gameObject.layer == 8)
            {
                Destroy(this.gameObject);
            }
            if (collision.gameObject.layer == 9)
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Destroy(this.gameObject);
                    
                }
                Destroy(collision.gameObject);
            }
            
        }
        else
        {
            if (collision.gameObject.tag == "inimigo")
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Destroy(this.gameObject);
                    GameControllerlvl2.instance.hpInimigo--;
                }
            }
            else if (collision.gameObject.layer == 8)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
