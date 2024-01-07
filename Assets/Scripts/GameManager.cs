using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject __FireManageButton;

    public bool exitCounterBool = false;
    public float exitCounter = 0.0f;

    public bool _fireCounterBool = false;
    public float _fireCounter = 0.0f;

    public bool _cookBool = false; //料理ができているかどうかのBool
    Text __fireButtonText;

    [SerializeField] private GameObject hourHand, minuteHand, secondHand;

    // Start is called before the first frame update
    void Start()
    {
        __fireButtonText = __FireManageButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameController gamecontroller = FindObjectOfType<GameController>();
        SceneSwitcher sceneswitcher = FindObjectOfType<SceneSwitcher>();

        if(exitCounterBool == true)
        {
            exitCounter += Time.deltaTime;
            if(exitCounter >= 10f)
            {
                Debug.Log("GameOver");
                exitCounter = 0.0f;
                sceneswitcher.GameOverFire();
            }
        }

        if (_fireCounterBool)
        {
            _fireCounter += Time.deltaTime;
            if(_fireCounter >= 50f && !_cookBool)
            {
                _cookBool = true;
                __fireButtonText.text = "お皿にうつす";
                Debug.Log("Cooked!!");
            }
        }

        //時計の針管理
        hourHand.transform.Rotate(Vector3.forward * -360f / 7200f * Time.deltaTime);
        minuteHand.transform.Rotate(Vector3.forward * -360f / 600f * Time.deltaTime);
        secondHand.transform.Rotate(Vector3.forward * -360f / 10f * Time.deltaTime);

        if(minuteHand.transform.eulerAngles.z <= -360)
        {
            sceneswitcher.GameOverTime();
        }

        //minuteHand.GetComponent<Transform>().localEulerAngles = new Vector3(90f, 0, -360f / 10.0f * Time.deltaTime); //長針
        //secondHand.GetComponent<Transform>().localEulerAngles = new Vector3(90f, 0, -360f / (1.0f/6.0f) * Time.deltaTime); //秒針
    }

    
}
