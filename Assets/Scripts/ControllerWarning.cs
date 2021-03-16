using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Levi Herring
/// 15/03/2021
/// Stick Fighter FMP
/// </summary>

public class ControllerWarning : ControllerManager
{

    public Texture2D _controllerWarningBackground;                                                                              //creates slot in inspector to assign the controller warning background
    public Texture2D _controllerWarningText;                                                                                    //slot in inspector for warning text message
    public Texture2D _controllerDetectedText;                                                                                   //slot in inspector to assign the controller detected text


    public float _controllerWarningFadeValue;                                                                                       //defines the fade value of the warning text 
    private float _controllerWarningFadeSpeed = 0.25f;                                                                                                //defines the fade speed
    private bool _controllerConditionsMet;                                                                                      //defines if the conditions are met for the game to continue 


    // Start is called before the first frame update
    void Start()
    {
        _controllerWarningFadeValue = 1;                                                                                        //fade value equals 1 on start up
        _controllerConditionsMet = false;                                                                                       //the conditions are not met on startup
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
