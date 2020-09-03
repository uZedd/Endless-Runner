using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject MainMenu;
    public Text HIGHSCORE;
    public int HighScoreScore;
    public int Score;

    public GameObject KUOLIT;
    public Text PISTEET;

    private int elämät = 1;
    
    
    
    void Start()
    {
        KUOLIT.SetActive(false);
        MainMenu.SetActive(true);
        Time.timeScale= 0.0f;
        HighScoreScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    
    void Update()
    {
        HIGHSCORE.text = "Ennätys: " + HighScoreScore;
        PISTEET.text = "Pisteet: " + Score;

        if (Input.GetKey(KeyCode.Escape) && elämät <= 0)
        {
            Time.timeScale = 1f;
            elämät = 1;
            Application.LoadLevel(0);
        }

        

        

        

        if(elämät <= 0)
        {
            KUOLIT.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }
    
    public void PisteetPlus(int NewScore)
    {
        Score += NewScore;
        if(Score >= HighScoreScore)
        {
            HighScoreScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScoreScore);
        }
    }

    //pelin aloittaminen
    public void ClickedStart()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    //Pelistä poistuminen
    public void ClickedQuit()
    {
        Application.Quit();
        //PlayerPrefs.DeleteAll();
    }

    //pdf:n avaaminen
    public void ClickedOhjeet()
    {
        
        Application.OpenURL("file:///E:/Jasper/Unity/EndlessRunner/Assets/Ohjeet.pdf");
    }

    public void TakeDamage()
    {
        elämät--;
    }

}
