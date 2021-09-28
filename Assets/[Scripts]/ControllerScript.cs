using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour
{
    public Rect gameScreen;
    public Rect screenSafeArea;

    public Rect BackButtonRect;

    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rect screenRect = new Rect(0.0f, 0.0f, Screen.width, Screen.height);
        gameScreen = screenRect;

        screenSafeArea = Screen.safeArea;
        CheckOrientation();
    }

    private static void CheckOrientation()
    {
        //Adjustment based on screen orientation changes
        switch (Screen.orientation)
        {
            case ScreenOrientation.LandscapeLeft:
                break;
            case ScreenOrientation.LandscapeRight:
                break;
            case ScreenOrientation.Portrait:
                break;
            default:
                break;
        }
    }
}
