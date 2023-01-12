using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isFinished = false;
    public bool isPlaying = false;
    public Timer timer;

    [SerializeField] private GameObject antiTeleport;
    [SerializeField] private GameObject final;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject robotButtonStart;
    [SerializeField] private TextMeshProUGUI remainingTimeText;
    [SerializeField] private Transform startingPoint;
    [SerializeField] private Transform player;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;

        ExitZone.OnFinished += Finish;
        Detection.OnFound += Found;
        Timer.OnTimeFinished += GameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        player.position = startingPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Finish()
    {
        print("game is finished");
        isFinished = true;

        float minutes = timer.minutes;
        float seconds = timer.seconds;
        float centiseconds = timer.centiseconds;

        //récupérer le timer score
        remainingTimeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, centiseconds);

        //faire apparaître un canva avec le score
        //proposer de rejouer etc...
        Vector3 canvasPosition = (player.transform.forward * 1.5f) + player.transform.position;
        final.transform.position = canvasPosition;
        final.SetActive(true);
        // + faire apparaître le canvas face au joueur

        //ne plus se téléporter
        antiTeleport.SetActive(true);
    }

    private void Found()
    {
        print("teleportation of player");
        player.position = startingPoint.position;
    }

    public void RobotRetry()
    {
        //SceneManager.LoadScene("SampleScene");
        Found();
        timer.RestartTimer();
        isPlaying = false;
        robotButtonStart.SetActive(true);
        gameOver.SetActive(false);
    }

    public void RobotQuit()
    {
        Application.Quit();
    }

    public void RobotStart()
    {
        //print("start game");
        isPlaying = true;
        antiTeleport.SetActive(false);
    }

    private void GameOver()
    {
        Vector3 canvasPosition = (player.transform.forward * 1.5f) + player.transform.position;
        gameOver.transform.position = canvasPosition;
        gameOver.SetActive(true);

        antiTeleport.SetActive(true);
    }
}
