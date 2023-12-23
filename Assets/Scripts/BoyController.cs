using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class BoyController : MonoBehaviour
{

    public Transform[] destinations; // 目的地のTransform
    private NavMeshAgent navMeshAgent;
    private int currentDestinationIndex = 0;
    private bool isWaiting = false;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameController gamecontroller = FindObjectOfType<GameController>();

        // 目的地に到達したら次の目的地を設定
        if (!gamecontroller.sleepBool)
        {
            navMeshAgent.enabled = true;
            if(navMeshAgent.remainingDistance < 2.0f && !navMeshAgent.pathPending && !isWaiting)
            {
                SetNextDestination();
                currentDestinationIndex++;
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
            sequence.AppendInterval(3f);
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

}
