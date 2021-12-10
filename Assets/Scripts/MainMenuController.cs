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
    private AudioController ac;
    public SoundValueHolder holder;
    private int MusicVolume = 10;
    private int EffectsVolume = 10;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        ac = GameObject.Find("AudioManager").GetComponent<AudioController>();

        holder = GameObject.Find("SoundValueHolder").GetComponent<SoundValueHolder>();
        MusicVolume = (int)(PlayerPrefs.GetFloat("MusicVolumeScale", 1) * 10);
        EffectsVolume = (int) (PlayerPrefs.GetFloat("EffectsVolumeScale", 1) * 10);
        MusicVolumeDisplay.text = "" + MusicVolume;
        EffectsVolumeDisplay.text = "" + EffectsVolume;
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
        PlayerPrefs.Save();
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
        ac.SetMusicVolumeScale(MusicVolume);
        PlayerPrefs.SetFloat("MusicVolumeScale", MusicVolume / 10f);

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
        ac.SetEffectsVolumeScale(EffectsVolume);
        PlayerPrefs.SetFloat("EffectsVolumeScale", EffectsVolume / 10f);
    }
}
