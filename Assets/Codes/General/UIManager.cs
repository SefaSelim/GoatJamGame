using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Health healthScript;
    public TextMeshProUGUI healthText;

    public void Start()
    {
        healthScript = FindObjectOfType<Health>();
        if (healthScript == null)
        {
            Debug.LogError("Health script not found!");
        }

    }

    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Play()
    {
        SceneManager.LoadScene("CutsceneForest-1");
    }

    public void UpdateHealthUI(int currenthealth)
    {
        healthText.text = "" + currenthealth.ToString();
    }
}