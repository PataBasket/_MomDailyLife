using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _FireManageButton;
    [SerializeField] private GameObject _SleepManageButton;

    public bool fireBool = false; //火がついているか付いていないかのBool
    public Text fireButtonText;

    public bool sleepBool = true; //子供が寝ているかどうかのBool
    public Text sleepButtonText;

    // Start is called before the first frame update
    void Start()
    {
        fireButtonText = _FireManageButton.GetComponentInChildren<Text>();
        sleepButtonText = _SleepManageButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "ActionTrigger")
        {
            if(fireBool == false)
            {
                fireButtonText.text = "火をつける";
            }
            else
            {
                fireButtonText.text = "火を消す";
            }

            _FireManageButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "ActionTrigger") //火場から離れた時に呼ばれる
        {
            GameManager gamemanager = FindObjectOfType<GameManager>();
            if (fireBool)
            {
                gamemanager.fireCounterBool = true;
            }

            _FireManageButton.SetActive(false);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SleepingPlace" && sleepBool == true)
        {
            sleepButtonText.text = "起こす";
            _SleepManageButton.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "SleepingPlace")
        {
            _SleepManageButton.SetActive(false);
        }
    }


}
