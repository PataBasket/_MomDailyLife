using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject FireManageButton;
    [SerializeField] private GameObject SleepManageButton;

    Text fireButtonText;
    //[SerializeField] private bool isPressed = false;

    private float pressCounter = 0;
    private bool onDish = false;

    // Start is called before the first frame update
    void Start()
    {
        fireButtonText = FireManageButton.GetComponentInChildren<Text>();
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
                if (gamemanager._cookBool && !onDish)
                {
                    fireButtonText.text = "火を消す";
                    onDish = true;
                    Debug.Log("盛り付け完了");
                }

                else if (gamecontroller.fireBool)
                {
                    gamecontroller.fireBool = false;
                    gamemanager._fireCounterBool = false;
                    gamemanager.exitCounterBool = false;
                    gamemanager.exitCounter = 0.0f;

                    fireButtonText.text = "火をつける";
                }

                else if (!gamecontroller.fireBool)
                {
                    gamecontroller.fireBool = true;
                    gamemanager._fireCounterBool = true;

                    fireButtonText.text = "火を消す";
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
                Debug.Log(gamecontroller.sleepBool); 

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
