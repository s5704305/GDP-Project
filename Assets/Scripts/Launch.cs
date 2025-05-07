using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Launch : MonoBehaviour
{
    //Text objects for the GUI
    public UnityEngine.UI.Text powerText;

    public UnityEngine.UI.Text ShotsLeftText;

    public UnityEngine.UI.Text ExtraShotsText;

    public bool keypressed = false;

    public Rigidbody myRigidbody;

    public int height = 0;

    public int turn = 0;

    public int power = 1;

    //These are for checking if the game should end


    int ShotPower = 0;

    public GameObject Cannon;

    public GameObject Cannonball;
    public Transform SpawnPoint;

    public Rigidbody CBP;

    public Vector3 Direction;


    public int AmmoRemaining = 10;

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

        if (Input.GetKeyDown (KeyCode.W) && power < 10) 
        {
            power += 1;
            powerText.text = "Power: " + power.ToString();
        }

        if (Input.GetKeyDown (KeyCode.S) && power > 0)
        {
            power -= 1;
            powerText.text = "Power: " + power.ToString();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            //resetting the ball by  making it not kinematic, rotating the cannon back, moving the ball before making it kinematic again and finally making it stay in place
            CBP.isKinematic = true;
            Cannon.transform.rotation = Quaternion.Euler(0, 180, 0);
            Cannonball.transform.position = SpawnPoint.transform.position;
            CBP.isKinematic = false;
            CBP.useGravity = false;
        }
    }
    void FixedUpdate()
    {
        
        while (keypressed == true)
        {
            //this mess of code will launch the ball by using the 3 forces, power, elevation and rotation
            myRigidbody.useGravity = true;
            ShotPower = power * -4;
            Direction = new Vector3(ShotPower, height, turn);
            myRigidbody.AddForce(Direction, ForceMode.Impulse);
            height = 0;
            turn = 0;
            keypressed = false;

            if (AmmoRemaining != 0)
            {
                AmmoRemaining -= 1;
                ShotsLeftText.text = "Shots Left: " + AmmoRemaining.ToString();
                
            }
            else
            {
                GameEnd();
            }
           
        }
    }
    void GameEnd()
    {
        ShotsLeftText.text = "Shots Left: 0. You lose!";
        Time.timeScale = 0;
        Thread.Sleep(5);
        Application.Quit();
    }
}