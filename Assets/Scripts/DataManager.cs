using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    //Current Navigational Tool
    enum Tool {miniMap, compass, none};
    [SerializeField] Tool currentTool;

    //MiniMap
    [SerializeField] private RawImage minimap;
    private RectTransform miniMapRT;

    //Timer
    private float totalPlayTime = 0f;
    private float timeLookingAtTool = 0f;

    // Start is called before the first frame update
    void Start()
    {
        miniMapRT = minimap.GetComponent<RectTransform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent())
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(miniMapRT, gazePoint.Screen))
            {
                minimap.color = Color.red;
                timeLookingAtTool += Time.deltaTime;
            }
            else
            {
                minimap.color = Color.white;
            }
        }

        //Timer
        totalPlayTime += Time.deltaTime;
    }

    private void OnApplicationQuit()
    {
        float percentTimeLookingAtTool = (timeLookingAtTool / totalPlayTime) * 100;

        Debug.Log(totalPlayTime);
        Debug.Log(timeLookingAtTool);
        Debug.Log(percentTimeLookingAtTool);
    }
}
