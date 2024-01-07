using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BoyController : MonoBehaviour
{

    public Transform[] destinations; // 目的地のTransform
    [SerializeField] private Transform breakfast;
    [SerializeField] private Transform goal;

    [SerializeField] private GameObject callButton;
    [SerializeField] private GameObject eatButton;
    [SerializeField] private GameObject sendButton;

    private NavMeshAgent navMeshAgent;
    private int currentDestinationIndex = 0;
    private bool isWaiting = false;
    public bool isOnBreakfast = false;
    public bool okToSend = false;
    public bool isGoing = false;

    private int temp_destination;
    Text callButtonText;
    Text eatButtonText;
    Text sendButtonText;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = false;

        callButtonText = callButton.GetComponentInChildren<Text>();
        eatButtonText = eatButton.GetComponentInChildren<Text>();
        sendButtonText = sendButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameController gamecontroller = FindObjectOfType<GameController>();
        ObjectFollowPlayer objectfollowplayer = FindObjectOfType<ObjectFollowPlayer>();

        // 目的地に到達したら次の目的地を設定
        if (!gamecontroller.sleepBool)
        {
            navMeshAgent.enabled = true;

            if (currentDestinationIndex == destinations.Length && objectfollowplayer.placedDish && !isOnBreakfast)
            {
                callButtonText.text = ("子供を呼ぶ");
                callButton.SetActive(true);
            }
            
            else if (navMeshAgent.remainingDistance < 2.0f && !navMeshAgent.pathPending && !isWaiting)
            {
                SetNextDestination();
                currentDestinationIndex++;
            }

            if (currentDestinationIndex != destinations.Length && objectfollowplayer.placedDish)
            {
                Debug.Log("子供が朝の支度を終えていません！！");
            }

            if (okToSend && !isGoing)
            {
                sendButtonText.text = ("おくる");
                sendButton.SetActive(true);
            }
        }
    }

    public void boyAwake()
    {
        Vector3 awakePosition = new Vector3(-10f, -0.9f, 22.5f);
        Quaternion awakeRotation = Quaternion.Euler(0f, 180f, 0f);

        this.transform.SetPositionAndRotation(awakePosition, awakeRotation);

        //_boy.transform
    }

    void SetNextDestination()
    {
        if (currentDestinationIndex < destinations.Length)
        {
            Transform nextDestination = destinations[currentDestinationIndex];
            navMeshAgent.SetDestination(nextDestination.position);

            // DOTweenを使って到着後に3秒間待機する
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() => isWaiting = true);
            sequence.AppendInterval(10f);
            sequence.AppendCallback(() =>
            {
                isWaiting = false;
                SetNextDestination();
            });
        }

        else
        {
            Debug.Log("All destinations reached");
            isWaiting = true;
        }
    }

    public void MoveToSpecificLocation()
    {
        Vector3 specificLocation = breakfast.position;
        navMeshAgent.SetDestination(specificLocation);
    }

    public void MoveToLastLocation()
    {
        Vector3 lastLocation = goal.position;
        navMeshAgent.SetDestination(lastLocation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Plate_01")
        {
            eatButtonText.text = "食べる";
            eatButton.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneSwitcher sceneswitcher = FindObjectOfType<SceneSwitcher>();
        if(collision.gameObject.name == "goal")
        {
            Debug.Log("Clear!!");
            sceneswitcher.ClearScene();
        }
    }

}
