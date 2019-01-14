using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerPartyStats : MonoBehaviour
{
    #region singleton

    private static _PlayerPartyStats instance = null;

    // Game Instance Singleton
    public static _PlayerPartyStats Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
    
    private void Start()
    {

    }

    private void Update()
    {
        
    }

}
