using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int GameTimer = 10;
    private float _currGameTimer;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI StartTimerText;
    public GameObject EndGamePanel;
    private TextMeshProUGUI EndGameText;

    private bool _gameStartPass = false;
    
    PlayerScript[] players;

    private float _startCD = 4;

    public static int LastHitten = -1;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        players = FindObjectsOfType<PlayerScript>();
        foreach (PlayerScript player in players)
        {
            player.enabled = false;
        }
        
        EndGameText = EndGamePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _currGameTimer = GameTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStartPass)
        {
            GameChrono();
        }
        else
        {
            GameStartCountDown();
        }
    }

    public void GameStartCountDown()
    {
        if (_startCD >= 0)
        {
            _startCD -= Time.deltaTime;
            StartTimerText.text = Mathf.CeilToInt(_startCD-1).ToString();

            if (_startCD <= 1f)
            {
                StartTimerText.text = "TANK!";
                StartTimerText.color = Color.yellow;
            }
        }
        else
        {
            StartTimerText.transform.parent.gameObject.SetActive(false);
            _gameStartPass = true;
            foreach (PlayerScript player in players)
            {
                player.enabled = true;
            }  
        }
    }

    public void GameChrono()
    {
        if (_currGameTimer <= 0)
        {
            GameEnd();
        }
        else
        {
            _currGameTimer -= Time.deltaTime;
            //TimerText.text = Mathf.CeilToInt(_currGameTimer).ToString();
        }
    }

    private void GameEnd()
    {
        //desactivate control
        foreach (PlayerScript player in players)
        {
            player.enabled = false;
        }

        Time.timeScale = 0;
        EndGamePanel.SetActive(true);
        Image EndGameImg = EndGamePanel.GetComponent<Image>();
        
        if (players[0].HitTaken > players[1].HitTaken)
        {
            //P2 Victory
            Debug.Log("P2 Victory");
            
            EndGameImg.color = new Color(0,0,1,.25f);
            EndGameText.text = "P2 Victory";
            EndGameText.color = Color.red;
        }
        else if (players[0].HitTaken < players[1].HitTaken)
        {
            //P1 Victory
            Debug.Log("P1 Victory");
            
            EndGameImg.color = new Color(1,0,0,.25f);
            EndGameText.text = "P1 Victory";
            EndGameText.color = Color.blue;
        }
        else
        {
            switch (LastHitten)
            {
                case 2:
                    Debug.Log("P1 Victory");
            
                    EndGameImg.color = new Color(1,0,0,.25f);
                    EndGameText.text = "P1 Victory";
                    EndGameText.color = Color.blue;
                    break;
                case 1:
                    Debug.Log("P2 Victory");
            
                    EndGameImg.color = new Color(0,0,1,.25f);
                    EndGameText.text = "P2 Victory";
                    EndGameText.color = Color.red;
                    break;
                default:
                    //égalité
                    Debug.Log("Egalité");
                                    
                    EndGameImg.color = new Color(1,1,1,.25f);;
                    EndGameText.text = "Tapez les gens!";
                    EndGameText.color = Color.black;
                    break;
            }
        }
    }
}
