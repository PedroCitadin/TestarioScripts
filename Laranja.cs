using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laranja : MonoBehaviour
{


    private SpriteRenderer sr;
    private CapsuleCollider2D circle;

    public GameObject collected;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            Destroy(gameObject, 1f);
            GameController.instance.laranja = true;
            GameController.instance.laranjaUI.SetActive(true);
        }
    }
}
