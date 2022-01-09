using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool pauseMenuOpen = false;
    public GameObject pauseMenuPanel;
    void Start()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SimLinkManager.Instance.StopSim();
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadSceneAsync("MenueScene");
    }

    public void RestartSim()
    {
        SimLinkManager.Instance.RestartSim();
        pauseMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuOpen)
            {
                pauseMenuPanel.SetActive(true);
                pauseMenuOpen = true;
                SimLinkManager.Instance.PauseSim();
            }
            else
            {
                pauseMenuPanel.SetActive(false);
                pauseMenuOpen = false;
                SimLinkManager.Instance.ResumeSim();
            }
        }
    }
}
