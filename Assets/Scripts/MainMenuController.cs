using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    private InputAction menuEsc;

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
        SceneManager.LoadScene("BasicLevel");
        mainMenu.SetActive(false);

        Time.timeScale = 1;
    }

    public void ExitOnClick()
    {
        //In Unity Editor mode the program does not actually quit
        Debug.Log("Quit");
        Application.Quit();
    }
}
