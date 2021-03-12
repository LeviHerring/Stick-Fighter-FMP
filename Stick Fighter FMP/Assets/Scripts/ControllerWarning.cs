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
    void Update()
    {
        if(_controllerDetected == true)                                                                             //if a controller is detected 
        {
            return;                                                                                                 //then do nothing and return
        }
    }

    private void OnGUI()
    {
        
    }
}
