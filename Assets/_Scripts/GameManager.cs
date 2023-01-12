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
    [SerializeField] private GameObject finalCanvas;
    [SerializeField] private GameObject robotButtonRetry;
    [SerializeField] private GameObject robotButtonQuit;
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
    }
    // Start is called before the first frame update
    void Start()
    {
       
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
        finalCanvas.SetActive(true);
        robotButtonRetry.SetActive(true);
        robotButtonQuit.SetActive(true);

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
        SceneManager.LoadScene("SampleScene");
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
}
