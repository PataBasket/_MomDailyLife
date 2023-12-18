using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MotherController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) 
        {
            Move(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
    }

    void Move(Vector3 direction)
    {
        // プレイヤーの向きを指定の方向に向ける
        transform.DOLookAt(transform.position + direction, 0.3f);

        // プレイヤーを指定の方向に動かす
        transform.Translate(direction * walkingSpeed * Time.deltaTime, Space.World);
    }
}
