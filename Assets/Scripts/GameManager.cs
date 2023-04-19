using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameManager : NetworkBehaviour
{

    #region Singleton
    public static GameManager instance;

    void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    public bool hasRaceStarted = false;
    public string displayedCounterValue;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchRaceCounter(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Server]
    private IEnumerator LaunchRaceCounter(int counterTime)
    {
        while(counterTime > 0) 
        {
            yield return new WaitForSeconds(1);
            RpcDisplayCounter(counterTime.ToString());
            counterTime--;
        }

        RpcDisplayCounter("Go!");
        hasRaceStarted = true;
    }

    [ClientRpc]
    void RpcDisplayCounter(string counterValue)
    {
        displayedCounterValue = counterValue;
    }

    [ClientRpc]
    void RpcDebugLog(string debug)
    {
        Debug.Log(debug);
    }
}
