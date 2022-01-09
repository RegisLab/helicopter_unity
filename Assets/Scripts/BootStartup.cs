using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//=============================================
//	Simulator Classes Loader
//=============================================
public class BootStartup : MonoBehaviour
{
    // link to objects
    public GameObject sim_link_manager;
    //TODO audio manager
    //TODO network manager
    //TODO lang manager


    // awake method (before game started)
    void Awake()
    // void Start()
    {
        if (SimLinkManager.Instance == null)
        {
            Instantiate(sim_link_manager);
        }
    }
}
