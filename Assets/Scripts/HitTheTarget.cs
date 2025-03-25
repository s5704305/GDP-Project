using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTheTarget : MonoBehaviour
{
    public GameObject Cannonball;
    public GameObject Cannon;
    public Transform SpawnPoint;
    public GameObject Target;
    public Rigidbody CBP;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CannonBall")
        {
            Destroy(Target);
        }
        CBP = collision.gameObject.GetComponent<Rigidbody>();
        // Turn off the physics of the ball so we don’t upset the physics engine by just
        // moving the ball.
        CBP.isKinematic = true;
        // Move the ball to the location of the SpawnPoint object.
        Cannon.transform.rotation = Quaternion.Euler(0, 180, 0);
        Cannonball.transform.position = SpawnPoint.transform.position;
        //Rotate = new Vector3(-0, 0, 0);
        //Cannon(transform.Rotate(Rotate));
        
        // Reset the physics of the ball now we have moved it.
        CBP.isKinematic = false;
        CBP.useGravity = false;
    }
}