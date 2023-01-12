using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotButton : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch(gameObject.tag)
            {
                case "RobotRetry":
                    GameManager.Instance.RobotRetry();
                    break;
                case "RobotQuit":
                    GameManager.Instance.RobotQuit();
                    break;
                case "RobotStart":
                    GameManager.Instance.RobotStart();
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
