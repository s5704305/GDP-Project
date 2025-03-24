using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    public GameObject Cannon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            Cannon.transform.Rotate(0, 2, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Cannon.transform.Rotate(0, -2, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Cannon.transform.Rotate(0, 0, 2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Cannon.transform.Rotate(0, 0, -2);
        }
    }
}
