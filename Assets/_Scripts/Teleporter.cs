using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class Teleporter : MonoBehaviour
{

 
    private bool active = false;
    private Rigidbody rb;
    public GameObject player;
    public GameObject Cube;
    public XRSocketInteractor attach;

    private Stopwatch timer = new();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        attach.StartManualInteraction(Cube.GetComponent<IXRSelectInteractable>());
    }

    public void OnGrabEnter()
    {
        timer.Reset();
    }
    public void OnGrabExited()
    {
        active = true;
        rb.isKinematic = false;
        rb.useGravity = true;

        timer.Start();
    }

    private void FixedUpdate()
    {
        if (timer.ElapsedMilliseconds >= 5000.0f)
        {
            attach.StartManualInteraction(Cube.GetComponent<IXRSelectInteractable>());
            timer.Reset();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!active)
        {
            return;
        }
        if(collision.gameObject.tag == "Ground")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            active = false;
            player.transform.position = position;

            attach.StartManualInteraction(Cube.GetComponent<IXRSelectInteractable>());

            collision.gameObject.GetComponent<TeleportationArea>()?.teleporting.Invoke(new TeleportingEventArgs());

        }
    }
}
