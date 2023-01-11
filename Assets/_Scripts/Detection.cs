using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject RobotLight;

    public delegate void FoundAction();
    public static event FoundAction OnFound;

    void OnTriggerEnter(Collider other) 
    {
        Vector3 direction = (Player.transform.position - RobotLight.transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);

        RaycastHit hit;

        if (Physics.Raycast( ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Coulé");
                OnFound();
            }
            else
            {
                Debug.Log("Oupsi");
            }
        }
    }
}
