using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private InputActionAsset controls;
    private InputAction menuEsc;
    private bool isMenuActive = false;

    //Awake is called before Start and works kind of like a constructor / initialisor
    private void Awake()
    {
        var gameplayActionMap = controls.FindActionMap("Navigation");
        menuEsc = gameplayActionMap.FindAction("MenuEsc");
    }
    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuEsc.WasReleasedThisFrame() && !isMenuActive)
        {
            Menu.SetActive(true);
            isMenuActive = true;

            Time.timeScale = 0;
        }

        else if (menuEsc.WasReleasedThisFrame() && isMenuActive)
        {
            Menu.SetActive(false);
            isMenuActive = false;

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
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
}
