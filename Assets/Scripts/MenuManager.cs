using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private Manager manager;
    [SerializeField] private GameObject dataManager;
    private DataManager dataManagerScript;

    private int experienceLevel = 0;

    [SerializeField] private Button[] button;
    private Button selectedButton;
    [SerializeField] private Button confirmButton;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameManager.GetComponent<Manager>();
        dataManagerScript = dataManager.GetComponent<DataManager>();

        button[0].onClick.AddListener(TaskOnClick0);
        button[1].onClick.AddListener(TaskOnClick1);
        button[2].onClick.AddListener(TaskOnClick2);
        button[3].onClick.AddListener(TaskOnClick3);
    }

    private void TaskOnClick0()
    {
        selectedButton = button[0];
    }

    private void TaskOnClick1()
    {
        selectedButton = button[1];
    }

    private void TaskOnClick2()
    {
        selectedButton = button[2];
    }

    private void TaskOnClick3()
    {
        selectedButton = button[3];
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (button[i] == selectedButton)
            {
                button[i].image.color = Color.green;
            }
            else
            {
                button[i].image.color= Color.white;
            }
        }
    }

    public void Button1()
    {
        experienceLevel = 1;
    }

    public void Button2()
    {
        experienceLevel= 2;
    }

    public void Button3()
    {
        experienceLevel= 3;
    }

    public void Button4()
    {
        experienceLevel= 4;
    }

    public void ConfirmButton()
    {
        dataManagerScript.SetExperienceLevel(experienceLevel);
        manager.PlayGame();
    }
}
