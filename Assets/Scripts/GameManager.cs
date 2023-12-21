using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool fireCounterBool = false;
    public float fireCounter = 0.0f;

    [SerializeField] private GameObject hourHand, minuteHand, secondHand;

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

        //時計の針管理
        hourHand.transform.Rotate(Vector3.forward * -360f / 7200f * Time.deltaTime);
        minuteHand.transform.Rotate(Vector3.forward * -360f / 600f * Time.deltaTime);
        secondHand.transform.Rotate(Vector3.forward * -360f / 10f * Time.deltaTime);

        //minuteHand.GetComponent<Transform>().localEulerAngles = new Vector3(90f, 0, -360f / 10.0f * Time.deltaTime); //長針
        //secondHand.GetComponent<Transform>().localEulerAngles = new Vector3(90f, 0, -360f / (1.0f/6.0f) * Time.deltaTime); //秒針
    }

}
