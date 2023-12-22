using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject FireManageButton;
    [SerializeField] private GameObject SleepManageButton;
    //[SerializeField] private bool isPressed = false;

    private float pressCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameController gamecontroller = FindObjectOfType<GameController>();
        GameManager gamemanager = FindObjectOfType<GameManager>();
        BoyController boycontroller = FindObjectOfType<BoyController>();

        if (Input.GetKey(KeyCode.Return) && FireManageButton.activeSelf)
        {
            pressCounter += Time.deltaTime;
            if(pressCounter >= 3)
            {
                FireManageButton.SetActive(false);

                if (gamecontroller.fireBool)
                {
                    gamecontroller.fireBool = false;
                    gamemanager.fireCounterBool = false;
                    gamemanager.fireCounter = 0.0f;
                }
                else if (!gamecontroller.fireBool)
                {
                    gamecontroller.fireBool = true;
                    Debug.Log("Fired");
                }

                //isPressed = false;
                pressCounter = 0;
            }
        }

        if(Input.GetKey(KeyCode.Return) && SleepManageButton.activeSelf)
        {
            pressCounter += Time.deltaTime;
            if(pressCounter >= 3)
            {
                SleepManageButton.SetActive(false);
                Debug.Log(gamecontroller.sleepBool); //=false

                if (gamecontroller.sleepBool)
                {
                    gamecontroller.sleepBool = false;
                    boycontroller.boyAwake();
                    Debug.Log("awake");
                }
                pressCounter = 0;
            }
        }

    }

}
