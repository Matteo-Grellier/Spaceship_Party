using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkManagerUI : MonoBehaviour
{
    public void client()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void server()
    {
        NetworkManager.Singleton.StartServer();
    }
    public void host()
    {
        NetworkManager.Singleton.StartHost();
    }
}
