using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField] private RawImage minimap;
    private RectTransform miniMapRT;

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
            }
            else
            {
                minimap.color = Color.white;
            }
        }
    }
}
