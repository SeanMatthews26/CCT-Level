using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Manager : MonoBehaviour
{
    private bool playingGame = false;

    private int maxCollectables = 8;
    private int collectablesCaught = 0;

    //Menu
    [SerializeField] GameObject firstButton;
    [SerializeField] GameObject menuObject;

    //Finish
    [SerializeField] GameObject finishObject;

    //Player
    [SerializeField] private GameObject player;
    private PlayerInput playerInput;
    private ThirdPersonController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);

        playerInput = player.GetComponent<PlayerInput>();
        playerControllerScript = player.GetComponent<ThirdPersonController>();

        Pause();
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

    private void FinishGame()
    {
        playingGame = false;
        Time.timeScale = 0f;
        playerControllerScript.enabled = false;

        finishObject.SetActive(true);
    }

    public int GetCollectablesCaught()
    {
        return collectablesCaught;
    }

    private void Pause()
    {
        playingGame = false;
        Time.timeScale = 0f;
        playerControllerScript.enabled= false;

        menuObject.SetActive(true);
    }
    
    public void PlayGame()
    {
        playingGame = true;
        Time.timeScale = 1f;
        playerControllerScript.enabled = true;

        menuObject.SetActive(false);
    }

    public bool GetPlayingGame()
    {
        return playingGame;
    }
}
