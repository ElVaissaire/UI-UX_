using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{
    public delegate void FinishAction();
    public static event FinishAction OnFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnFinished();
        }
    }
}
