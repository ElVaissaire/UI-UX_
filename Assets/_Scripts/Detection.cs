using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject EnemiesLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Vector3 direction = (player.transform.position - EnemiesLight.transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);

        RaycastHit hit;

        Debug.Log("Touché");

        if (Physics.Raycast( ray, out hit))
        {
            if (hit.collider.gameObject.tag == "player")
            {
                Debug.Log("Coulé");
            }
            else
            {
                Debug.Log("Oupsi");
            }
        }
    }
}
