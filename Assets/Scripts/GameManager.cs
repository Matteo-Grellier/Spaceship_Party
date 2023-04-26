using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
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

    // reference to the localPlayer
    public GameObject localPlayer;

    public CameraFollow playerCamera;
    
    public Spaceship winner;
    public Vector3 leftMapBorderPosition = new Vector3(-25, 0, 500);
    public Vector3 rightMapBorderPosition = new Vector3(25, 0, 500);

    // List of all the players in the game
    private static Dictionary<string, Spaceship> players = new Dictionary<string, Spaceship>();
    
    [SerializeField] private GameObject launchBtn;
    [SerializeField] private GameObject winnerText;

    [SerializeField] private GameObject startCounter;
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

        if(winner != null)
            FinishGame();
    }

    private void FinishGame() 
    {
        hasRaceStarted = false;

        GameObject winnerName = winnerText.transform.GetChild(1).gameObject;

        winnerName.GetComponent<TextMeshProUGUI>().text = winner.name;
        winnerText.SetActive(true);
       
        playerCamera.blockedCameraPosition = CameraFollow.BlockedAxes.none;
        playerCamera.blockedCameraRotation = CameraFollow.BlockedAxes.none;
        playerCamera.Target = winner.transform;
        playerCamera.offset = new Vector3(0f, 10f, 0f);
        Debug.Log(playerCamera.offset);


        foreach(KeyValuePair<string, Spaceship> player in players) 
        {
            player.Value.SetInteractableSliders(false);
            player.Value.SetSlidersValue(0f);
        }
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

    // private void OnGUI() 
    // {
    //     GUILayout.BeginArea(new Rect(200,200,200,500));
    //     GUILayout.BeginVertical();
    //     foreach(string playerId in players.Keys)
    //     {
    //         GUILayout.Label(playerId + " - " + players[playerId].transform.name);
    //     }
    //     GUILayout.EndVertical();
    //     GUILayout.EndArea();
    // }

    public void LaunchRaceIfServer()
    {
        StartCoroutine(LaunchRaceCounter(10));
        launchBtn.SetActive(false);
        RpcManageCounter(true);
    }

    [Server]
    private IEnumerator LaunchRaceCounter(int counterTime)
    {
        while(counterTime >= 0) 
        {
            yield return new WaitForSeconds(1);
            
            RpcDisplayCounter(counterTime.ToString());
            counterTime--;
        }

        RpcDisplayCounter("Go!");
        yield return new WaitForSeconds(1);

        RpcLaunchRace();
        hasRaceStarted = true;
        RpcManageCounter(false);
    }

    [ClientRpc]
    void RpcDisplayCounter(string counterValue)
    {
        displayedCounterValue = counterValue;
        startCounter.GetComponent<TextMeshProUGUI>().text = displayedCounterValue;
        RpcDebugLog(counterValue);
    }

    [ClientRpc]
    void RpcManageCounter(bool isActive)
    {
        startCounter.SetActive(isActive);
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
