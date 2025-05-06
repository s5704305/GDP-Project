using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAmmo : MonoBehaviour
{
    
    public GameObject Cannon;
    public GameObject Cannonball;
    public Transform SpawnPoint;
    public GameObject Target;
    public Rigidbody CBP;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "CannonBall")
        {
            Destroy(Target);
            AmmoRemaining += 2;
        }
        CBP = collision.gameObject.GetComponent<Rigidbody>();
        // Turn off the physics of the ball so we don’t upset the physics engine by just
        // moving the ball.
        CBP.isKinematic = true;
        // Move the ball to the location of the SpawnPoint object.
        Cannon.transform.rotation = Quaternion.Euler(0, 180, 0);
        Cannonball.transform.position = SpawnPoint.transform.position;
        // Reset the physics of the ball now we have moved it.
        CBP.isKinematic = false;
        CBP.useGravity = false;
       
    }
}