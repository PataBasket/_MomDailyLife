using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool fireCounterBool = false;
    public float fireCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameController gamecontroller = FindObjectOfType<GameController>();

        if(fireCounterBool == true)
        {
            fireCounter += Time.deltaTime;
            if(fireCounter >= 10f)
            {
                Debug.Log("GameOver");
                fireCounter = 0.0f;
            }
        }
    }

}
