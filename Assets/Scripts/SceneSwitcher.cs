using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // シーン名
    public string targetSceneName;
    [SerializeField] private GameObject[] instructions;
    [SerializeField] private GameObject canvas_objects;

    private int screenCounter = 0;
    private bool isReading = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReading == true && screenCounter == 0)
        {
            instructions[0].SetActive(true);
            screenCounter++;
        }
        else if ((isReading == true && screenCounter == 1) && Input.GetKeyDown(KeyCode.P))
        {
            instructions[0].SetActive(false);
            instructions[1].SetActive(true);
            screenCounter++;
        }
        else if ((isReading == true && screenCounter == 2) && Input.GetKeyDown(KeyCode.P))
        {
            instructions[1].SetActive(false);
            instructions[2].SetActive(true);
            screenCounter++;
        }
        else if ((isReading == true && screenCounter == 3) && Input.GetKeyDown(KeyCode.P))
        {
            instructions[2].SetActive(false);
            instructions[3].SetActive(true);
            screenCounter++;
        }
        else if ((isReading == true && screenCounter == 4) && Input.GetKeyDown(KeyCode.P))
        {
            instructions[3].SetActive(false);
            screenCounter = 0;
            LeaveInstruction();
        }
    }

    // ボタンが押されたときに呼ばれるメソッド
    public void StartButtonPress()
    {
        // シーンの切り替え
        SceneManager.LoadScene(targetSceneName);
    }

    public void GameInstructions()
    {
        isReading = true;
        canvas_objects.SetActive(false);

    }

    public void LeaveInstruction()
    {
        isReading = false;
        canvas_objects.SetActive(true);
    }
}
