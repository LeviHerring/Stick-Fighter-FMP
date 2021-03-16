using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controller Warning
/// Levi Herring
/// 10/03/2021
/// </summary>

public class ControllerManager : MonoBehaviour

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
    void Update()
    {
        //if(_controllerDetected == true)                                                                             //if a controller is detected 
        //{
            //return;                                                                                                 //then do nothing and return
        //}
    }

     void LateUpdate()
    {
        string[] _joyStickNames = Input.GetJoystickNames();                                                            //_joyStickNames = getjoysticknames from an inbuilt input

        for(int _js = 0; _js < _joyStickNames.Length; _js++)                                                            //js increase counter _js based on joystick names length
        {
            if(_joyStickNames [_js].Length == 19)                                                                        //if the name of the joystick is the code for a ps4 controller 19
            {
                _pS4Controller = true;                                                                                   //set ps4 controller to true
                _controllerDetected = true;                                                                              //set controller detected to true
            }
            if (_joyStickNames[_js].Length == 33)                                                                        //if the name of the joystick is the code for a xbox controller 33
            {
                _xBOXController = true;                                                                                //set xbox controller to true
                _controllerDetected = true;                                                                              //set controller detected to true
            }
            if(_joyStickNames[_js].Length != 0)                                                                         //if _joysticknames is not equal to zero
            {
                return;                                                                                                 //then do noth8ing and returhn
            }
            if (string.IsNullOrEmpty(_joyStickNames[_js]))                                                               //if there is no controller detected 
            {
                _controllerDetected = false;                                                                            //set controller detected to false
            }
                

        }
           

    }

    private void OnGUI()
    {
        if (_startUpFinished == false)                                                                                   //if startup finished equals false
        {
            return;                                                                                                     //then do nothing and return
        }
        if (_controllerDetected == true)                                                                               //a controller is detected 
        {
            return;                                                                                                     //then do nothing and return
        }
        if(_controllerDetected == false)                                                                              //if a controller is not detected
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _controllerNotDetected);                     //draw texture at this position by these dimensions draw the controller not detected texutre
        }
    }
}
