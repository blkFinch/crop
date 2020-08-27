using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityExtensions;
public enum PlayerEquipState { Hoe, Water }
public class Player : MonoBehaviour
{
    public static Player active;

    private PlayerEquipState equipped;

    public PlayerEquipState Equipped { get => equipped; }

    void Awake()
    {
        if(active != null) { Destroy(this.gameObject); }
        else{ active = this; }

        equipped = PlayerEquipState.Hoe;
    }

    public void CycleEquipState(){
        equipped = equipped.Next();
    }
}
