using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTImer : MonoBehaviour
{
    public float timeRemaining = 120;

    [SerializeField]
    private TextMeshProUGUI timerGUI;

    [SerializeField]
    private GameObject gameOverCanvas;

    [SerializeField]
    private GameObject gameCanvas;


    private Vector3 zeroScale = new Vector3(0, 0, 0);


    private Vector3 bigScale = new Vector3(1, 1, 1);


    private void Start()
    {
       gameOverCanvas.transform.localScale = zeroScale;
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if(timeRemaining < 0)
        {
            gameCanvas.transform.localScale = zeroScale;
            gameOverCanvas.transform.localScale = bigScale;


        }

        DisplayTime(timeRemaining);
    }


    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerGUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
