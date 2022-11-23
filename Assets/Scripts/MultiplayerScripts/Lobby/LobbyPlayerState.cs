using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Networking.Transport;
using UnityEngine;

public struct LobbyPlayerState : INetworkSerializable
{
    public ulong CLientId;
    public string PlayerName;
    public bool IsReady;

    public LobbyPlayerState(ulong clientId, string playerName, bool isReady)
    {
        clientId = clientId;
        PlayerName= playerName;
        IsReady= isReady;
    }

    public void NetworkSerialize<T>(NetworkSerializer serializer) where T : IReaderWriter
    {
        serializer.Serialize(ref CLientId);
    }
}
