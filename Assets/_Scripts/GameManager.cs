using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject antiTeleport;
    [SerializeField] private GameObject finalCanvas;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;

        ExitZone.OnFinished += Finish;
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
        //faire apparaître un canva avec le score
        //proposer de rejouer etc...
        finalCanvas.SetActive(true);

        //ne plus se téléporter
        antiTeleport.SetActive(true);
    }
}
