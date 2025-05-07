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

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "CannonBall")
        {
            Destroy(Target);
        }
        CBP = collision.gameObject.GetComponent<Rigidbody>();
        CBP.isKinematic = true;
        Cannon.transform.rotation = Quaternion.Euler(0, 180, 0);
        Cannonball.transform.position = SpawnPoint.transform.position;
        CBP.isKinematic = false;
        CBP.useGravity = false;
    }
}