using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    public int vidas;
    private Animator anim;
    public Transform spawnPoint;
   
    public GameObject itemPrefab; // o prefab do item que será lançado
    public float throwForce = 20f;
    // Start is called before the first frame update
   
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        verificaMorte();
        fly();
        poder();
    }

    void move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal")>0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
         if(Input.GetAxis("Horizontal")<0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if(Input.GetAxis("Horizontal")==0f){
            anim.SetBool("walk", false);
        }
        
    }

    void fly()
    {
        if (SceneManager.GetActiveScene().name == "lvl_1")
        {
            if (GameController.instance.abacaxi)
            {

                rig.gravityScale = 0f;
                Vector3 movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
                transform.position += movement * Time.deltaTime * Speed;



            }
        }
        else
        {
            if (GameControllerlvl2.instance.abacaxi)
            {

                rig.gravityScale = 0f;
                Vector3 movement = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
                transform.position += movement * Time.deltaTime * Speed;



            }
        }
        
        

        
    }
    void poder()
    {
        if (SceneManager.GetActiveScene().name == "lvl_1")
        {
            if (GameController.instance.kiwi)
            {
                if (Input.GetButtonDown("Fire1"))
                {

                    if (transform.rotation.y == 0f)
                    {
                        GameObject item = Instantiate(itemPrefab, new Vector3(transform.position.x + 0.3f, transform.position.y + 0.3f, 0f), transform.rotation);
                        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 2f), ForceMode2D.Impulse);
                    }
                    else if (transform.rotation.y != 0f)
                    {
                        GameObject item = Instantiate(itemPrefab, new Vector3(transform.position.x - 0.3f, transform.position.y + 0.3f, 0f), transform.rotation);
                        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 2f), ForceMode2D.Impulse);
                    }
                }
            }
        }
        else
        {
            if (GameControllerlvl2.instance.kiwi)
            {
                if (Input.GetButtonDown("Fire1"))
                {

                    if (transform.rotation.y == 0f)
                    {
                        GameObject item = Instantiate(itemPrefab, new Vector3(transform.position.x + 0.3f, transform.position.y + 0.3f, 0f), transform.rotation);
                        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 2f), ForceMode2D.Impulse);
                    }
                    else if (transform.rotation.y != 0f)
                    {
                        GameObject item = Instantiate(itemPrefab, new Vector3(transform.position.x - 0.3f, transform.position.y + 0.3f, 0f), transform.rotation);
                        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 2f), ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    void jump(){

        if (SceneManager.GetActiveScene().name == "lvl_1")
        { 

            if (!GameController.instance.abacaxi)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rig.gravityScale = 1f;
                if (GameController.instance.laranja)
                {
                    if (!isJumping)
                    {
                        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                        doubleJump = true;
                        isJumping = true;
                        anim.SetBool("jump", false);
                    }
                    else
                    {
                        if (doubleJump)
                        {
                            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                            doubleJump = false;

                        }
                    }
                }
            }
        }
        }
        else
        {
            if (!GameControllerlvl2.instance.abacaxi)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rig.gravityScale = 1f;
                    if (GameControllerlvl2.instance.laranja)
                    {
                        if (!isJumping)
                        {
                            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                            doubleJump = true;
                            isJumping = true;
                            anim.SetBool("jump", false);
                        }
                        else
                        {
                            if (doubleJump)
                            {
                                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                                doubleJump = false;

                            }
                        }
                    }
                }
            }
        }
    }

    void verificaMorte()
    {
        if (SceneManager.GetActiveScene().name == "lvl_1")
        {
            if (transform.position.y < -5.6f)
            {
                
                GameController.instance.vidas--;
                
                if (GameController.instance.vidas > 0)
                {
                    transform.position = spawnPoint.position;
                    
                }

            }
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "lvl_1")
        {
            if (collision.gameObject.layer == 9)
            {
                GameController.instance.vidas--;

                if (GameController.instance.vidas > 0)
                {
                    transform.position = spawnPoint.position;

                }
            }

                if (collision.gameObject.layer == 8)
            {
                rig.gravityScale = 1f;
                isJumping = false;
            }

            if (collision.gameObject.tag == "EndLevel")
            {
                GameController.instance.passaFase();
            }
        }
        else
        {
            if (collision.gameObject.layer == 8)
            {
                rig.gravityScale = 1f;
                isJumping = false;
            }

            
        }
    }

    

    
}
