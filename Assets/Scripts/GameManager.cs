using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void awake()
    {
        Cursor.visible = false;                                                                                                     //cursor bnot visible on awake
        Cursor.lockState = CursorLockMode.Locked;                                                                                   //lock cursor on awake
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                                                                                    //DON'T DESTORY GAmwe object when loading a new scene
    }

    // Update is called once per frame
    void Update()
    {

    }
}
