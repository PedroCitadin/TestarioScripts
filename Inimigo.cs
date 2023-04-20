using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float speed = 2f;
    public float speedV = 2f;
    float[] myVector = { 0f ,1.0f, 2f, 3f };
    public bool facingRight;
    public GameObject itemPrefab;
    
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPointInimigo").transform;
        facingRight = false;
        Invoke("poder", Random.Range(10.0f, 15.0f));
    }

    // Update is called once per frame
    void Update()
    {
        move();
        moveVert();
        if (speed>0 && !facingRight)
        
        {
            flip();  
        }else if(speed<0 && facingRight)
        {
            flip();
        }
        voltaProMeio();
       // poder();
    }


    void poder()
    {
        if (transform.rotation.y == 0)
        {
            GameObject item = Instantiate(itemPrefab, new Vector3(transform.position.x+0.5f, transform.position.y + 0.5f, 0f), transform.rotation);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 2f), ForceMode2D.Impulse);
        }
        else if (transform.rotation.y != 0)
        {
            GameObject item = Instantiate(itemPrefab, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.5f, 0f), transform.rotation);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 2f), ForceMode2D.Impulse);
        }
        Invoke("poder", Random.Range(0.3f, 1.0f));
    }
    
    void move()
    {
        int randomIndex = Random.Range(0, myVector.Length);
        Vector3 movement = new Vector3(myVector[randomIndex], 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
        if (transform.position.x <=-4f)
        {
            speed *= -1;
        }
        else if(transform.position.x >= 6f) 
        {
            speed *= -1;
        }
    }
    void moveVert()
    {
        int randomIndex = Random.Range(0, myVector.Length);
        Vector3 movement = new Vector3(0f, myVector[randomIndex], 0f);
        transform.position += movement * Time.deltaTime * speedV;
        if (transform.position.y <= 0.28f)
        {
            speedV *= -1;
        }
        else if (transform.position.y >= 3.23f)
        {
            speedV *= -1;
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    void voltaProMeio()
    {
        if (transform.position.x >6.5f || transform.position.x <-4.5f)
        {
            transform.position = spawnPoint.position;
        }

        if (transform.position.y > 3.5f || transform.position.y < 0.25f)
        {
            transform.position = spawnPoint.position;
        }
    }

    }
