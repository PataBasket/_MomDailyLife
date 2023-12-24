using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _FireManageButton;
    [SerializeField] private GameObject _SleepManageButton;
    [SerializeField] private Transform _minuteHand;

    public bool fireBool = false; //火がついているか付いていないかのBool
    public Text _fireButtonText;

    public bool sleepBool = true; //子供が寝ているかどうかのBool
    public Text sleepButtonText;

    // Start is called before the first frame update
    void Start()
    {
        _fireButtonText = _FireManageButton.GetComponentInChildren<Text>();
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
            GameManager gamemanager = FindObjectOfType<GameManager>();
            gamemanager.exitCounterBool = false;
            gamemanager.exitCounter = 0f;

            if (fireBool == false)
            {
                _fireButtonText.text = "火をつける";
            }
            else
            {
                _fireButtonText.text = "火を消す";
            }

            _FireManageButton.SetActive(true);
        }

        if(collider.gameObject.tag == "grabbable")
        {
            ObjectFollowPlayer grabbingClass = FindObjectOfType<ObjectFollowPlayer>();
            grabbingClass.isFront = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "ActionTrigger") //火場から離れた時に呼ばれる
        {
            GameManager gamemanager = FindObjectOfType<GameManager>();
            if (fireBool)
            {
                gamemanager.exitCounterBool = true;
            }

            _FireManageButton.SetActive(false);
        }

        if (collider.gameObject.tag == "grabbable")
        {
            ObjectFollowPlayer grabbingClass = FindObjectOfType<ObjectFollowPlayer>();
            grabbingClass.isFront = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        float minute_check = _minuteHand.rotation.eulerAngles.z;
        if(collision.gameObject.tag == "SleepingPlace" && sleepBool == true && minute_check <= 120f)
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
