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

    public GameObject localPlayer;

    public bool hasRaceStarted = false;
    public string displayedCounterValue;
    
    void Start()
    {
        StartCoroutine(LaunchRaceCounter(10));
    }

    private void Update() 
    {
        if(localPlayer == null )
            localPlayer = NetworkClient.localPlayer.gameObject;
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
