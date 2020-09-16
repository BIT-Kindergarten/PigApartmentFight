using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    PlayerManager PM;
    CharacterStats mystats;

    private void Start()
    {
        PM = PlayerManager.instance;
        mystats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playercombat = PM.Player.GetComponent<CharacterCombat>();
        if(playercombat!=null)
        {
            playercombat.Attack(mystats);
        }
    }
}
