using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimulatorLink;
using System.Diagnostics;

//=============================================
//	Simulator Link Manager
//=============================================


public class SimLinkManager : MonoBehaviour {
    private static SimLinkManager _instance;

    private Process _simProcess;

    public static SimLinkManager Instance { get { return _instance; } }

    public bool IsOk{ get; set; }

    private SimBridge simBridge;// = new SimBridge("127.0.0.1", 34674, 34675);

    public void StartBridge()
    {
        // simBridge.ExitSim();
        ExecSimulator(); 
        simBridge = new SimBridge("127.0.0.1", 34674, 34675);
        simBridge.StartBridge();
    }

    public void StartSim()
    {
        simBridge.StartSim();
    }

    public void PauseSim()
    {
        simBridge.PauseSim();
    }

    public void ResumeSim()
    {
        simBridge.ResumeSim();
    }

    public void ExitSim()
    {
        simBridge.ExitSim();
    }

    public void RestartSim()
    {
        simBridge.RestartSim();
    }

    public void StopSim()
    {
        simBridge.StopSim();
    }

    public int GetModelCount()
    {
        // int modelCount;
        // modelCount = simBridge.ModelCount;
        return simBridge.ModelCount;
    }

    public double GetModelStateVecComponent(int modelId, int componentId)
    {
        // int modelCount;
        // modelCount = simBridge.ModelCount;
        return simBridge.ModelsState[modelId].state[componentId];
    }

    public bool CheckModelStatus(int id)
    {
        return simBridge.ModelsState[id].status;
    }

    void OnApplicationQuit()
    {
        simBridge.ExitSim();
        simBridge.StopReceive();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        StartBridge();

        DontDestroyOnLoad(this.gameObject);
    }

    public void ExecSimulator()
    {
        _simProcess = new System.Diagnostics.Process();
        // ProcessStartInfo startInfo = new ProcessStartInfo();
        _simProcess.StartInfo.FileName = "/home/argus/projects/struct_swarm_controls/build/main";
        _simProcess.StartInfo.UseShellExecute = false;
        _simProcess.StartInfo.CreateNoWindow = true;
        _simProcess.StartInfo.RedirectStandardOutput = false;
        _simProcess.Start();
    }
}


// public class SimLinkManager : MonoBehaviour
// {
//     public static SimLinkManager instance = null;

// 	// public string testField;

//     void Start()
//     {
//         // Checking for instance existence
//         if (instance == null) // manager instance is find
//         {
//             instance = this;
//         }
//         else if(instance == this) // instance is exit
//         {
//             Destroy(gameObject);
//         }

// 		// if scene is changed, don't destroy object
// 		// DontDestroyOnLoad(gameObject);

// 		InitializeManager();
//     }

//     void Awake()
//     {
//         DontDestroyOnLoad(gameObject);
//     }

// 	private void InitializeManager()
// 	{
// 		// testField = "ggg";
// 	}
    
// }