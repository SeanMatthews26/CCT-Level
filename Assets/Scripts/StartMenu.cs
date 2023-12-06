using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstButton;

    [SerializeField] private GameObject dataManager;
    private DataManager dataManagerScript;

    [SerializeField] private TextMeshProUGUI _1;
    [SerializeField] private TextMeshProUGUI _2;
    [SerializeField] private TextMeshProUGUI _3;

    // Start is called before the first frame update
    void Start()
    {
        dataManagerScript = dataManager.GetComponent<DataManager>();

        EventSystem.current.SetSelectedGameObject(firstButton);

        _1.GetComponent<CanvasRenderer>().SetAlpha(0);
        _2.GetComponent<CanvasRenderer>().SetAlpha(0);
        _3.GetComponent<CanvasRenderer>().SetAlpha(0);

        SetUpNumbers(dataManagerScript.GetCurrentTool());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            dataManagerScript.SetCurrentTool(1);

            _1.GetComponent<CanvasRenderer>().SetAlpha(1);
            _2.GetComponent<CanvasRenderer>().SetAlpha(0);
            _3.GetComponent<CanvasRenderer>().SetAlpha(0);
        }

        if (Input.GetKeyDown("2"))
        {
            dataManagerScript.SetCurrentTool(2);

            _1.GetComponent<CanvasRenderer>().SetAlpha(0);
            _2.GetComponent<CanvasRenderer>().SetAlpha(1);
            _3.GetComponent<CanvasRenderer>().SetAlpha(0);
        }

        if (Input.GetKeyDown("3"))
        {
            dataManagerScript.SetCurrentTool(3);

            _1.GetComponent<CanvasRenderer>().SetAlpha(0);
            _2.GetComponent<CanvasRenderer>().SetAlpha(0);
            _3.GetComponent<CanvasRenderer>().SetAlpha(1);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void SetUpNumbers(int i)
    {
        if(i == 1)
        {
            _1.GetComponent<CanvasRenderer>().SetAlpha(1);
        }
        else if(i == 2)
        {
            _2.GetComponent<CanvasRenderer>().SetAlpha(1);
        }
        else if(i == 3)
        {
            _3.GetComponent<CanvasRenderer>().SetAlpha(1);
        }
    }
}
