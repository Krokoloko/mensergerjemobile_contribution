using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    /// <summary>
    /// This script manages the main menu and stores the amount of players selected
    /// </summary>

    public static ButtonManager Instance
    {
        get;
        set;
    }

    public int players = 2;
    [SerializeField]
    private Canvas _menu;
    [SerializeField]
    private Canvas _options;

    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        Instance = this;
        _menu.enabled = true;
        _options.enabled = false;

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        _menu.enabled = false;
        _options.enabled = true;
    }
    public void Menu()
    {
        _menu.enabled = true;
        _options.enabled = false;
    }
}