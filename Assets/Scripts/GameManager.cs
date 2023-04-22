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
    [SerializeField] private GameObject launchBtn;

    public bool hasRaceStarted = false;
    public string displayedCounterValue;

    private void Start() 
    {
        if (isServer)
            launchBtn.SetActive(true);
    }

    private void Update() 
    {
        if(localPlayer == null )
            localPlayer = NetworkClient.localPlayer.gameObject;
    }

    public void LaunchRaceIfServer()
    {
        StartCoroutine(LaunchRaceCounter(10));
        launchBtn.SetActive(false);
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
        RpcLaunchRace();
        hasRaceStarted = true;
    }

    [ClientRpc]
    void RpcDisplayCounter(string counterValue)
    {
        displayedCounterValue = counterValue;
        Debug.Log(counterValue);
        RpcDebugLog(counterValue);
    }

    [ClientRpc]
    void RpcLaunchRace()
    {
        hasRaceStarted = true;
    }

    [ClientRpc]
    void RpcDebugLog(string debug)
    {
        Debug.Log(debug);
    }
}
