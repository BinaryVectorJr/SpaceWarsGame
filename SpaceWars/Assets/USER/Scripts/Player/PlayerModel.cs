using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerModel : Mirror.NetworkBehaviour
{
    /// <summary>
    /// A structure that keeps track of what a Player Model comprises of - the type it is and the gameobject itself
    /// </summary>
    [Serializable]
    public struct playerModelsStruct
    {
        public PlayerSettings.playerTypes playerType;
        public GameObject playerPrefab;
    }

    [SerializeField]
    public List<playerModelsStruct> playerModelsList = new List<playerModelsStruct>();

    public Transform targetParent;

    public void SetupPlayerModel(PlayerSettings.playerTypes _playerType)
    {
        var _playerGO = Instantiate(playerModelsList.First(x => x.playerType == _playerType).playerPrefab, targetParent, false);

        //FALLBACK CODE FOR SWITCH STATEMENT - USE THIS IF LINQ IS NOT WORKING PROPERLY, ESSENTIALLY THIS IS REDUNDANT CODE
        //switch (_playerType)
        //{
        //    case PlayerSettings.playerTypes.Normal:
        //        var playerNormalGO = Instantiate(playerModelsList.First(x => x.playerType == _playerType).playerPrefab);
        //        playerNormalGO.transform.parent = targetParent;
        //        break;

        //    case PlayerSettings.playerTypes.Fast:
        //        var playerFastGO = Instantiate(playerModelsList.First(x => x.playerType == _playerType).playerPrefab);
        //        playerFastGO.transform.parent = targetParent;
        //        break;

        //    case PlayerSettings.playerTypes.Brute:
        //        var playerBruteGO = Instantiate(playerModelsList.First(x => x.playerType == _playerType).playerPrefab);
        //        playerBruteGO.transform.parent = targetParent;
        //        break;

        //    default:
        //        break;
        //}
    }
}
