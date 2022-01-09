using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class AppController : MonoBehaviour
{

    private SimLinkManager simLinkManager_;
    // public int uavCount;
    public GameObject mainMenuButtons;
    public GameObject quitMenuButtons;
    private bool simStarted = false;
    private string simulationSceneName;

    // Start is called before the first frame update
    void Start()
    {
        // simLinkManager_ = GetComponent<SimLinkManager>();
        // simLinkManager_ = SimLinkManager.Instance;
        // SimLinkManager.Instance.StartBridge();
        
        // SimLinkManager.Instance.ExecSimulator();
        simStarted = true;
        // simLinkManager_.IsOk = true;

        simulationSceneName = "SampleScene";
        // string check = simLinkManager_.GetComponent<IsOk>;

        for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; sceneIndex++)
        {
            var scene = SceneManager.GetSceneAt(sceneIndex);
            if(scene == SceneManager.GetSceneByName(simulationSceneName))
            {
                SceneManager.UnloadSceneAsync(simulationSceneName);
            }
            // if(scene == SceneManager.GetSceneByName("PauseMenuScene"))
            // {
            //     SceneManager.UnloadSceneAsync("PauseMenuScene");
            // }
            
        }

        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartSimulation()
    {
       SceneManager.LoadScene(simulationSceneName);
       SimLinkManager.Instance.StartSim();
    }

    public void ShowSettingsMenu()
    {

    }

    public void ShowSetupMenu()
    {

    }
    public void ShowMainMenu()
    {
        mainMenuButtons.SetActive(true);
        quitMenuButtons.SetActive(false);
    }

    public void ShowQuitMenu()
    {
        mainMenuButtons.SetActive(false);
        quitMenuButtons.SetActive(true);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    
}


