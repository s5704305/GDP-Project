using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    
    public bool keypressed = false;

    public Rigidbody myRigidbody;

    public int height = 0;

    public int turn = 0;

    public GameObject Cannonball;
    public Transform SpawnPoint;

    public Rigidbody CBP;

    public Vector3 Direction;
    void Start()
    {
       
        myRigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keypressed = true;
        }
        if (Input .GetKeyDown(KeyCode.UpArrow)) {
            height += 1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            height -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            turn -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            turn += 1;
        }
    }
    void FixedUpdate()
    {
        while (keypressed == true)
        {
            myRigidbody.useGravity = true;
            Direction = new Vector3(-20, height, turn);
            myRigidbody.AddForce(Direction, ForceMode.Impulse);
            height = 0;
            turn = 0;
            keypressed = false;
        }
    }
}