using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float distance = 1.0f;
    public float horizontal_distance = 0.5f;
    private bool isGrabbing = false;

    public bool isFront = false;
    public bool puttable = false;

    [SerializeField] private Transform SecondObject;

    void Update()
    {
        // Fキーが押されたら追従を開始
        if (Input.GetKeyDown(KeyCode.C) && isFront)
        {
            isGrabbing = true;
        }

        // Fキーが離されたら追従を停止
        if (Input.GetKeyUp(KeyCode.C))
        {
            isGrabbing = false;
        }

        // 追従中の処理
        if (isGrabbing)
        {
            // プレイヤーの正面に配置
            Vector3 targetPosition = playerTransform.position + new Vector3(0, 3.8f, 0)
                + playerTransform.forward * distance + playerTransform.right * horizontal_distance;
            transform.position = targetPosition;

            SecondObject.position = targetPosition + playerTransform.right * -2*horizontal_distance;
        }
    }
}

