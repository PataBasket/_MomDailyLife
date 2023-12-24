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
    public bool placedDish = false;

    [SerializeField] private Transform SecondObject;

    void Update()
    {
        GameManager gamemanager = FindObjectOfType<GameManager>();

        // Fキーが押されたら追従を開始
        if (Input.GetKeyDown(KeyCode.C) && isFront && gamemanager._cookBool)
        {
            isGrabbing = true;
        }

        // Fキーが離されたら追従を停止
        if (Input.GetKeyUp(KeyCode.C) && !puttable && isGrabbing)
        {
            Debug.Log("そこには置けません！");
            
        }

        else if(Input.GetKeyUp(KeyCode.C) && puttable && isGrabbing)
        {
            isGrabbing = false;
            FoodPlacement();
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

    void FoodPlacement()
    {
        transform.position = new Vector3(9.15f, 1.6f, -21.2f);
        SecondObject.position = new Vector3(10.85f, 1.6f, -21.2f);

        placedDish = true;
    }
}

