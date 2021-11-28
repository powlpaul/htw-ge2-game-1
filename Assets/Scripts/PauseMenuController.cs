using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private InputActionAsset controls;
    private InputAction menuEsc;
    private bool isPauseMenuActive = false;

    //Awake is called before Start and works kind of like a constructor / initialisor
    private void Awake()
    {
        var gameplayActionMap = controls.FindActionMap("Navigation");
        menuEsc = gameplayActionMap.FindAction("MenuEsc");
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuEsc.WasReleasedThisFrame() && !isPauseMenuActive)
        {
            pauseMenu.SetActive(true);
            isPauseMenuActive = true;

            Time.timeScale = 0;
        }

        else if (menuEsc.WasReleasedThisFrame() && isPauseMenuActive)
        {
            pauseMenu.SetActive(false);
            isPauseMenuActive = false;

            Time.timeScale = 1;
        }
    }
    public void ResetOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReturnOnClick()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
