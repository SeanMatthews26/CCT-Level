using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private Manager manager;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeLimit;
    private float remainingTime;

    private void Start()
    {
        manager = gameManager.GetComponent<Manager>();
        remainingTime = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.playingGame)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime <= 0)
            {
                remainingTime = 0;
                manager.FinishGame();
                timerText.color = Color.red;
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
