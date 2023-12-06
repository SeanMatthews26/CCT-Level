using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject dataManager;
    private DataManager dataManagerScript;

    public bool playingGame = false;

    private int maxCollectables = 8;
    private int collectablesCaught = 0;

    //StartMenu
    [SerializeField] GameObject startMenu;

    //Menu
    [SerializeField] GameObject firstButton;
    [SerializeField] GameObject menuObject;
    [SerializeField] GameObject timerObject;

    //Finish
    [SerializeField] GameObject finishObject;

    //Player
    [SerializeField] private GameObject player;
    private PlayerInput playerInput;
    private ThirdPersonController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //EventSystem.current.SetSelectedGameObject(firstButton);

        dataManagerScript = dataManager.GetComponent<DataManager>();

        playerInput = player.GetComponent<PlayerInput>();
        playerControllerScript = player.GetComponent<ThirdPersonController>();

        StartMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect()
    {
        collectablesCaught++;

        //Debug.Log(collectablesCaught);

        if(collectablesCaught >= maxCollectables)
        {
            FinishGame();
        }
    }

    private void StartMenu()
    {
        playingGame = false;
        Time.timeScale = 0f;
        timerObject.SetActive(false);
        playerControllerScript.enabled = false;

        startMenu.SetActive(true);
        menuObject.SetActive(false);
        finishObject.SetActive(false);
    }

    public void QuestionMenu()
    {
        playingGame = false;
        Time.timeScale = 0f;
        playerControllerScript.enabled = false;
        timerObject.SetActive(false);

        startMenu.SetActive(false);
        menuObject.SetActive(true);
        finishObject.SetActive(false);
    }

    public void PlayGame()
    {
        playingGame = true;
        Time.timeScale = 1f;
        playerControllerScript.enabled = true;
        timerObject.SetActive(true);
        dataManagerScript.SetUpToolUI();

        menuObject.SetActive(false);
    }

    public void FinishGame()
    {
        playingGame = false;
        Time.timeScale = 0f;
        playerControllerScript.enabled = false;

        dataManagerScript.OutputData();

        startMenu.SetActive(false);
        menuObject.SetActive(false);
        finishObject.SetActive(true);
    }

    public int GetCollectablesCaught()
    {
        return collectablesCaught;
    }

    public bool GetPlayingGame()
    {
        return playingGame;
    }
}
