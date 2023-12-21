using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject FireManageButton;
    [SerializeField] private bool isPressed = false;

    private float pressCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            pressCounter += Time.deltaTime;
            if(pressCounter >= 3)
            {
                FireButtonExecution();

                GameController gamecontroller = FindObjectOfType<GameController>();
                GameManager gamemanager = FindObjectOfType<GameManager>();
                if (gamecontroller.fireBool)
                {
                    gamecontroller.fireBool = false;
                    gamemanager.fireCounterBool = false;
                    gamemanager.fireCounter = 0.0f;
                }
                else if (!gamecontroller.fireBool)
                {
                    gamecontroller.fireBool = true;
                }

                isPressed = false;
                pressCounter = 0;
            }
        }
    }

    public void FireButtonExecution()
    {
        FireManageButton.SetActive(false);
    }
}
