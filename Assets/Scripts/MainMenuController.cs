using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] GameObject mainMenuItems;
    [SerializeField] GameObject optionMenuItems;
    [SerializeField] private Text MusicVolumeDisplay;
    [SerializeField] private Text EffectsVolumeDisplay;
    private float MusicVolume = 10;
    private float EffectsVolume = 10;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartOnClick()
    {
        SceneManager.LoadScene("LevelVar1");
        mainMenu.SetActive(false);

        Time.timeScale = 1;
    }

    public void ExitOnClick()
    {
        //In Unity Editor mode the program does not actually quit
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OptionOnClick()
    {
        mainMenuItems.SetActive(false);
        optionMenuItems.SetActive(true);
    }

    public void BackOnClick()
    {
        mainMenuItems.SetActive(true);
        optionMenuItems.SetActive(false);
    }

    public void MusicButtonClick(bool right)
    {
        if(right && MusicVolume < 10)
        {
            MusicVolume++;
           
        }else if(!right && MusicVolume > 0)
        {
            MusicVolume--;
        }

        MusicVolumeDisplay.text = "" +  MusicVolume;
    }

    public void EffectsButtonClick(bool right)
    {
        Debug.Log("effect button was clicked: " + right);
        if (right && EffectsVolume < 10)
        {
            EffectsVolume++;

        }
        else if (!right && EffectsVolume > 0)
        {
            EffectsVolume--;
        }

        EffectsVolumeDisplay.text = "" + EffectsVolume;
    }
}
