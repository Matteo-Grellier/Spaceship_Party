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
            RpcDebug(counterTime.ToString());
            counterTime--;
        }

        // RpcStartRace();
        RpcDebug("[START GAME]");
        hasRaceStarted = true;
    }

    // [ClientRpc]
    // void RpcStartRace()
    // {
    //     Debug.Log("start my game duuude");
    // }

    [ClientRpc]
    void RpcDebug(string debug)
    {
        Debug.Log(debug);
    }
}
