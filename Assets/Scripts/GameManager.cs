using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class GameManager : NetworkBehaviour
{

    #region Singleton
    public static GameManager instance;

    public Vector3 leftMapBorderPosition = new Vector3(-25, 0, 500);
    public Vector3 rightMapBorderPosition = new Vector3(25, 0, 500);

    void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    // reference to the localPlayer
    public GameObject localPlayer;
    // List of all the players in the game
    private static Dictionary<string, Spaceship> players = new Dictionary<string, Spaceship>();
    
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

    public static void RegisterPlayer(string netID, Spaceship spaceship)
    {
        string newPlayerName = "Player" + netID;
        players.Add( newPlayerName, spaceship);
        spaceship.transform.name = newPlayerName;
    }

    public static void UnregisterPlayer(string playerId)
    {
        players.Remove(playerId);
    }

    private void OnGUI() 
    {
        GUILayout.BeginArea(new Rect(200,200,200,500));
        GUILayout.BeginVertical();
        foreach(string playerId in players.Keys)
        {
            GUILayout.Label(playerId + " - " + players[playerId].transform.name);
        }
        GUILayout.EndVertical();
        GUILayout.EndArea();
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
