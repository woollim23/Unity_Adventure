using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOption : MonoBehaviour
{
    [SerializeField] GameObject settingScreen;
    private bool isSetOn = false;
    void Start()
    {
        CharacterManager.Instance.Player.controller.onSettingScreen += SettingOpen;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSetOn()
    {
        isSetOn = !isSetOn;
    }

    void SettingOpen()
    {
        Debug.Log("SettingOpen()");
        ToggleSetOn();
        settingScreen.SetActive(isSetOn);

        if(isSetOn == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
