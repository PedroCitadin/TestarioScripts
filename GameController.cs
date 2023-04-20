using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int vidas;
    public static GameController instance;
    public Text scoreText;
    
    public bool laranja;
    public bool abacaxi;
    public bool banana;
    public bool kiwi;
    
    
    public GameObject personagem;
    public GameObject laranjaUI;
    public GameObject abacaxiUI;
    public GameObject kiwiUI;
    public GameObject bananaUI;

    // Start is called before the first frame update
    void Start()
    {
        
            vidas = 3;
            laranja = false; abacaxi = false; banana = false;kiwi = false;
        
        
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        atualizaVida();
        verificaVidas();
        
    }


    public void atualizaVida()
    {
        scoreText.text = vidas.ToString();
    }

    void verificaVidas()
    {
        if (vidas <= 0)
        {
            PlayerPrefs.DeleteAll();
            Destroy(personagem);
            Invoke("loadGameOver", 1f);
        }
    }
    
    void loadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    

    public void passaFase()
    {

        PlayerPrefs.SetInt("vidas", vidas);
        PlayerPrefs.SetInt("laranja", laranja ? 1 : 0);
        PlayerPrefs.SetInt("banana", banana ? 1 : 0);
        PlayerPrefs.SetInt("kiwi", kiwi ? 1 : 0);
        PlayerPrefs.SetInt("abacaxi", abacaxi ? 1 : 0);

        SceneManager.LoadScene("lvl_2");
    }
}
