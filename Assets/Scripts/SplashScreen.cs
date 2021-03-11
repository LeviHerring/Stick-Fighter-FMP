using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

/// <summary>
/// SplashScreen.cs
/// Levi Herring
/// 04/03/2021
/// </summary>

[RequireComponent(typeof(AudioSource))]                                                                       //add audio source when attaching the script
public class SplashScreen : MonoBehaviour
{

    public Texture2D _splashScreenBackground;                                                            //Create slot in inspector to assign splash screen background image
    public Texture2D _splashScreenText;                                                                 //Create slot in inspector to assign splash screen text

    private AudioSource _splashScreenAudio;                                                                  //Defines naming convention for Audio Source component
    public AudioClip _splashScreenMusic;                                                                     //Create slot in inspector to assign splash screen music 

    private float _splashScreenFadeValue;                                                                    //defines fade value 
    private float _splashScreenFadeSpeed = 0.15f;                                                            //defines fade speed

    private SplashScreenController _splashScreenController;                                              //Defines naming convention for splash screen controller
    private enum SplashScreenController                                                                  //Defines states splashscreen from splash screen
    {
        SplashScreenFadeIn = 0,
        SplashScreenFadeOut = 1
    }

     void Awake()
    {
        _splashScreenFadeValue = 0;                                                                     //fade value = 0 on startup

    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;                                                                         //set cursor visible state to false
        Cursor.lockState = CursorLockMode.Locked;                                                       //to lock the cursor
                
        _splashScreenAudio = GetComponent<AudioSource>();                                           //splash screen causes the audio source

        _splashScreenAudio.volume = 0;                                                                   //Audio volume = 0 on startup
        _splashScreenAudio.clip = _splashScreenMusic;                                               //Audio clip = splash screen music
        _splashScreenAudio.loop = true;                                                             //set Audio to loop
        _splashScreenAudio.Play();                                                                  //Play Audio :)

        _splashScreenController = SplashScreen.SplashScreenController.SplashScreenFadeIn;           //state = fade in on start up


        StartCoroutine("SplashScreenManager");                                                     //start splash screen manager function


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SplashScreenManager()
    {
        while(true)
        {
            switch (_splashScreenController)
            {
                case SplashScreenController.SplashScreenFadeIn:
                    SplashScreenFadeIn();
                    break;
                case SplashScreenController.SplashScreenFadeOut:
                    SplashScreenFadeOut();
                    break;

            }
            yield return null;
        }
    }

    private void SplashScreenFadeIn()
    {
        Debug.Log("SplashScreenFadeIn");

        _splashScreenAudio.volume += _splashScreenFadeSpeed * Time.deltaTime;                       //increase volume by fadespeed 
        _splashScreenFadeValue += _splashScreenFadeSpeed * Time.deltaTime;                          //increase fade value by fade speed

        if(_splashScreenFadeValue >  1)                                                             //if fade value is greater than 1
        {
            _splashScreenFadeValue = 1;                                                            //then set fade value to 1
        }

        if(_splashScreenFadeValue == 1)                                                            //if fade value = 1 
        {
            _splashScreenController = SplashScreen.SplashScreenController.SplashScreenFadeOut;    //set splash screen controller to equal splash screen fade out
        }
    }

    private void SplashScreenFadeOut()
    {
        Debug.Log("SplashScreenFadeOut");

            _splashScreenAudio.volume -= _splashScreenFadeSpeed * Time.deltaTime;                       //decrease volume by fadespeed 
            _splashScreenFadeValue -= _splashScreenFadeSpeed * Time.deltaTime;                          //decrease fade value by fade speed

        if (_splashScreenFadeValue < 0)                                                             //if fade value islessthan 0
        {
            _splashScreenFadeValue = 0;                                                            //then set fade value to 0
        }

        if(_splashScreenFadeValue == 0)                                                            //if fade value equals zero
        {
            EditorSceneManager.LoadScene("ControllerWarning");                                     //load scene controller warning
        }
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _splashScreenBackground);      //draw texture starting at 0,0 by the screen width and height and draw the background texture

        GUI.color = new Color(1,1,1,_splashScreenFadeValue);                                        //gui colour is equal to (1,1,1) plus the fade value



        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _splashScreenText);      //draw texture starting at 0,0 by the screen width and height and draw the splash screen text texture


        




    }
}
