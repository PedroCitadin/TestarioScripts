using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameControllerlvl2 : MonoBehaviour
{
    public int vidas;
    public static GameControllerlvl2 instance;
    public Text scoreText;
    public Text scoreTextInimigo;
    public int hpInimigo;
    public bool laranja;
    public bool abacaxi;
    public bool banana;
    public bool kiwi;
    
    public GameObject personagem;
    public GameObject inimigo;
    // Start is called before the first frame update
    void Start()
    {
        
              laranja = (PlayerPrefs.GetInt("laranja") != 0);
               abacaxi = (PlayerPrefs.GetInt("abacaxi") != 0);
               banana = (PlayerPrefs.GetInt("banana") != 0);
               kiwi = (PlayerPrefs.GetInt("kiwi") != 0);
               vidas = PlayerPrefs.GetInt("vidas");
               hpInimigo = 20;
               
        
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        atualizaVida();
        verificaVidas();
        verificaVidaInimigo();
    }


    public void atualizaVida()
    {
        scoreText.text = vidas.ToString();
        scoreTextInimigo.text = hpInimigo.ToString();
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
    void verificaVidaInimigo()
    {
        if (hpInimigo <= 0)
        {
            PlayerPrefs.DeleteAll();
            
            Destroy(inimigo);
            Invoke("loadYouWin", 1f);
        }
    }

    void loadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    void loadYouWin()
    {
        SceneManager.LoadScene("YouWin");
    }

}
