using Mirror;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasHUD : MonoBehaviour
{

    public GameObject PanelOffline, PanelGame;
    
    private string actualScene, lastScene;
    public Button buttonHost, buttonServer, buttonClient, buttonStop;

    public InputField inputFieldAddress;

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
          case "Scene_Room":
            RoomScene();
            break;
          case "GameScene":
            GameScene();
            break;
          case "Scene_Offline":
            OfflineScene();
            break;
        }

        //This updates the Unity canvas, we have to manually call it every change, unlike legacy OnGUI.
        SetupCanvas();
    }
    private void Update() {
      actualScene = SceneManager.GetActiveScene().name;
      bool hasChanged = false;
      if (lastScene != actualScene)
      {
        hasChanged = true;
      }
      if (hasChanged == true)
      {
        hasChanged = false;
        lastScene = actualScene;
        Start();
      }
    }
    public void OfflineScene()
    {
        PanelOffline.SetActive(true);
        PanelGame.SetActive(false);

        buttonHost.onClick.AddListener(ButtonHost);
        buttonServer.onClick.AddListener(ButtonServer);
        buttonClient.onClick.AddListener(ButtonClient);

        inputFieldAddress.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void GameScene() 
    {
        Destroy(GameObject.Find("Background"));
        PanelOffline.SetActive(false);
        PanelGame.SetActive(true);
        buttonStop.onClick.AddListener(ButtonStop);
    }

    public void RoomScene()
    {
      PanelOffline.SetActive(false);
      PanelGame.SetActive(false);
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        NetworkManager.singleton.networkAddress = inputFieldAddress.text;
    }

    public void ButtonHost()
    {
        NetworkManager.singleton.StartHost();
        SetupCanvas();
    }

    public void ButtonServer()
    {
        NetworkManager.singleton.StartServer();
        SetupCanvas();
    }

    public void ButtonClient()
    {
        NetworkManager.singleton.StartClient();
        SetupCanvas();
    }

    public void ButtonStop()
    {
        // stop host if host mode
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        // stop client if client-only
        else if (NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopClient();
        }
        // stop server if server-only
        else if (NetworkServer.active)
        {
            NetworkManager.singleton.StopServer();
        }
        Destroy(gameObject);
        SetupCanvas();
    }

    public void SetupCanvas()
    {
        DontDestroyOnLoad(gameObject);
        Update();
    }
}