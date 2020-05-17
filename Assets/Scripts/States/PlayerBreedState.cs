using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreedState : PlayerBaseState
{
    public override void Enter(PlayerController playerController)
    {
        // game finished
        playerController.PlayerBreedState();
    }

    public override void Exit(PlayerController playerController)
    {

    }

    public override void FixedUpdate(PlayerController playerController)
    {

    }

    public override void Update(PlayerController playerController)
    {

    }
}
