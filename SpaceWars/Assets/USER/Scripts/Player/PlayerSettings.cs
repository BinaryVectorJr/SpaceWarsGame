using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : Mirror.NetworkBehaviour
{
    public enum playerTypes
    {
        Normal,
        Fast,
        Brute
    }

    [Mirror.SyncVar]
    public playerTypes playerObjType = playerTypes.Normal;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }
}
