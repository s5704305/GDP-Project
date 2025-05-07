using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraAmmo : MonoBehaviour
{
    
    public GameObject Cannon;
    public GameObject Cannonball;
    public Transform SpawnPoint;
    public GameObject Target;
    public Rigidbody CBP;
    public int AmmoGained = 0;
    public UnityEngine.UI.Text ShotsText;


    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.name == "CannonBall")
        {
            Destroy(Target);
            GameObject cb = GameObject.Find("CannonBall");
            if (cb == null)
            {
                Debug.LogError("Failed to find CannonBall");
            }
            Launch L = cb.GetComponent<Launch>();
            if (L == null)
            {
                Debug.LogError("Failed to find Launch Script");
            }
            L.AmmoRemaining += 3;
            ShotsText.text = "Shots Left: " + L.AmmoRemaining.ToString(); 

           
        }
        CBP = collision.gameObject.GetComponent<Rigidbody>();
        CBP.isKinematic = true;
        Cannon.transform.rotation = Quaternion.Euler(0, 180, 0);
        Cannonball.transform.position = SpawnPoint.transform.position;
        CBP.isKinematic = false;
        CBP.useGravity = false;
       
    }
}