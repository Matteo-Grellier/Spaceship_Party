using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LobbyUI : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private LobbyPlayerCard[] lobbyPlayerCards;
    [SerializeReference] private startGameButton[];

    private NetworkList<>;
}
