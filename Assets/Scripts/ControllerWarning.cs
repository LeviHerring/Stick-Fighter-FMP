using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controller Warning
/// Levi Herring
/// 10/03/2021
/// </summary>

public class ControllerWarning : MonoBehaviour

{
    public Texture2D _controllerNotDetected;                                                                                 //Creates slot in inspector to assign a controller not detected warning text

    public bool _pS4Controller;                                                                                    //creates a bool for when a ps4 controller is connected 
    public bool _xBOXController;                                                                                   //creates a bool for when an xbox controller is connected 
    public bool _controllerDetected;                                                                               //creates bool for when a controller is active

    public static bool _startUpFinished;                                                                           //creates bool for when start up is finished 

     void Awake()
    {
        _pS4Controller = false;                                                                                       //ps4 controller is false on awake
        _xBOXController = false;                                                                                      //xbox contro0ller is false on awake
        _controllerDetected = false;                                                                                  //no controller detected on awake

        _startUpFinished = false;                                                                                   //starty up finished is false on awake
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                                                                     //don't destroy this game object when loading a new scene
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
            _controllerWarningFadeValue == 0;                                                               //then set the value to equal zero
        }

        if (_controllerWarningFadeValue == 0)                                                        //if fade value is 0
        {
            _startupFinished = true;                                                                 //set startup finish to true
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
