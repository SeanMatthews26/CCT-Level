using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private Manager manager;

    //Current Navigational Tool
    enum Tool {MINIMAP, COMPASS, NONE};
    [SerializeField] Tool currentTool;
    private GameObject currentToolGameObject;
    private RectTransform currentToolRT;

    //MiniMap
    [SerializeField] private GameObject minimap;

    //Compass
    [SerializeField] private GameObject compass;

    //Timer
    private float totalPlayTime = 0f;
    private float timeLookingAtTool = 0f;
    private float[] timeToGetCollectables;
    private float[] timeWatchingToolPerCollectable;

    private int experienceLevel;

    public class Test
    {
        public string name = "Sean";
        public int num = 400;
    }

    public Test myTest = new Test();

    // Start is called before the first frame update
    void Start()
    {
        manager = gameManager.GetComponent<Manager>();

        timeToGetCollectables = new float[8];
        timeWatchingToolPerCollectable = new float[8];

        for (int i =0; i < 8; i++)
        {
            timeToGetCollectables[i] = 0;
        }

        for (int i = 0; i < 8; i++)
        {
            timeWatchingToolPerCollectable[i] = 0;
        }

        switch (currentTool)
        {
            case Tool.MINIMAP:
                currentToolGameObject = minimap;
                currentToolRT = minimap.GetComponent<RectTransform>();

                minimap.SetActive(true);
                compass.SetActive(false);
                break;

            case Tool.COMPASS: 
                currentToolGameObject = compass;
                currentToolRT = compass.GetComponent<RectTransform>();

                minimap.SetActive(false);
                compass.SetActive(true);
                break;

            case Tool.NONE:
                currentToolGameObject= null;
                currentToolRT = null;

                minimap.SetActive(false);
                compass.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent())
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(currentToolRT, gazePoint.Screen))
            {
                currentToolGameObject.GetComponent<RawImage>().color = Color.red;
                timeLookingAtTool += Time.deltaTime;

                if (manager.GetCollectablesCaught() < timeToGetCollectables.Length)
                {
                    TimeWatchingToolPerCollectable(manager.GetCollectablesCaught());
                }
            }
            else
            {
                currentToolGameObject.GetComponent<RawImage>().color = Color.white;
            }
        }

        //Timer
        totalPlayTime += Time.deltaTime;
        if(manager.GetCollectablesCaught() < timeToGetCollectables.Length)
        {
            TimeToGetCollectables(manager.GetCollectablesCaught());
        }
    }

    private void OutputJson()
    {
        string strOutput = JsonUtility.ToJson(myTest);

        File.WriteAllText(Application.dataPath + "/DataFiles/text.json", strOutput);
    }

    private void OnApplicationQuit()
    {
        OutputJson();

        float percentTimeLookingAtTool = (timeLookingAtTool / totalPlayTime) * 100;
        float[] percentTimeLookingAtToolsPerCollectable = new float[8];

        for (int i = 0; i < 8; i++)
        {
            percentTimeLookingAtToolsPerCollectable[i] = (timeWatchingToolPerCollectable[i] / timeToGetCollectables[i]) * 100;
        }

        Debug.Log("Total Play Time = " + totalPlayTime);
        Debug.Log("Time Looking At the Tool is = " + timeLookingAtTool);
        Debug.Log("The percentage looking at tool is = " + percentTimeLookingAtTool + "%");
        Debug.Log("Time to Get collectable 1 was = " + timeToGetCollectables[0]);
        Debug.Log("Time to Get collectable 2 was = " + timeToGetCollectables[1]);
        Debug.Log("Time to Get collectable 3 was = " + timeToGetCollectables[2]);
        Debug.Log("Time to Get collectable 4 was = " + timeToGetCollectables[3]);
        Debug.Log("Time to Get collectable 5 was = " + timeToGetCollectables[4]);
        Debug.Log("Time to Get collectable 6 was = " + timeToGetCollectables[5]);
        Debug.Log("Time to Get collectable 7 was = " + timeToGetCollectables[6]);
        Debug.Log("Time to Get collectable 8 was = " + timeToGetCollectables[7]);

        Debug.Log("Experience Level = " + experienceLevel);

        //Percentages per tool
        /*for (int i = 0; i < 8; i++)
        {
            Debug.Log("Percent time looking at tool while finding collectable " + (i + 1) + " was = " + percentTimeLookingAtToolsPerCollectable[i]);
        }*/
    }

    private void TimeToGetCollectables(int collectableCaught)
    {
        timeToGetCollectables[collectableCaught] += Time.deltaTime;
    }

    private void TimeWatchingToolPerCollectable(int collectableCaught) 
    {
        timeWatchingToolPerCollectable[collectableCaught] += Time.deltaTime;
    }

    public void SetExperienceLevel(int level)
    {
        experienceLevel= level;
    }
}
