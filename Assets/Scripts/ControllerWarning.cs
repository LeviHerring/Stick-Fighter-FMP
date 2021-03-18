using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Controller Warning
/// Levi Herring
/// 10/03/2021
/// </summary>

public class ControllerWarning : ControllerManager

{
    public Texture2D _controllerWarningBackground;                                                                          //assing the background for the warning
    public Texture2D _controllerWarningText;                                                                               //assign the text for warning
    public Texture2D _controllerDetectedText;                                                                               //creates slot in inspector to 

    public float _controllerWarningFadeValue;                                                                       //defines for fade value of the text 
    private float _controllerWarningFadeSpeed = 0.25f;                                                                  //defines fade speed for warning text
    private bool _controllerConditionsMet;                                                                                //defines if the controller conditions are met for the game to continue


     void Awake()
    {
                                                                                        //starty up finished is false on awake
    }

    // Start is called before the first frame update
    void Start()
    {
        _controllerWarningFadeValue = 1;                                                                                //makes the fade value one
        _controllerConditionsMet = false;                                                                               //conditions are not met on startup
    }

    // Update is called once per frame
    //void Update()
    //{
        //if(_controllerDetected == true)                                                                             //if a controller is detected 
        //{
            //return;                                                                                                 //then do nothing and return
        //}
    //}

    void Update()
    {
        if (_controllerDetected == true)                                           //if a controller is detected
        {
            StartCoroutine("WaitToLoadMainMenu");                                   //start function
        }

        if (_controllerConditionsMet == false)                                        //if the conditions are not met
        {
            return;                                                                   //do nothing and retunr                                   
        }

        if (_controllerConditionsMet == true)                                        //the conditions are met 
        {
            _controllerWarningFadeValue -= _controllerWarningFadeSpeed * Time.deltaTime;   //the decrease value by the fade speed times time delta time
        }

        if (_controllerWarningFadeValue < 0)                                                                 //if the fade value is less than zero
        {
            _controllerWarningFadeValue = 0;                                                               //then set the value to equal zero
        }

        if (_controllerWarningFadeValue == 0)                                                        //if fade value is 0
        {
            _startUpFinished = true;                                                                 //set startup finish to true
            SceneManager.LoadScene("MainMenu");                                                                     //load main menu
        }
    }

    private IEnumerator WaitToLoadMainMenu()                                        //
    {
        yield return new WaitForSeconds(2);                                         //wait for this many seconds, 2

        _controllerConditionsMet = true;                                            //set the conditions met to true

    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _controllerWarningBackground);                                         //draw a texture at the corner of the screen 0,0 background

        GUI.color = new Color(1, 1, 1, _controllerWarningFadeValue);                                                                        //gui colour is equal to black pls fade value

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _controllerWarningText);                                                //draw the warning text

        if (_controllerDetected == true)                                                                                                    //IF DETEcted is true
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _controllerDetectedText);                                                //draw the detected text
        }
    }
}
