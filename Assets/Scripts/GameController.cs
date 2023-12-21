using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _FireManageButton;

    public bool fireBool = false; //火がついているか付いていないかのBool
    public Text fireButtonText;

    // Start is called before the first frame update
    void Start()
    {
        fireButtonText = _FireManageButton.GetComponentInChildren<Text>();
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
            
        }
        _FireManageButton.SetActive(false);
    }
}
