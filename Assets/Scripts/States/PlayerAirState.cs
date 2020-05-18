using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{

    private bool isOnIsland = false;
    private bool isOnBreedingIsland = false;
    public override void Enter(PlayerController pc)
    {
        // todo animation flying
        pc.GetComponent<SpriteRenderer>().sprite = pc.air;
    }

    public override void Exit(PlayerController pc)
    {
        isOnIsland = false;
        isOnBreedingIsland = false;
    }

    public override void FixedUpdate(PlayerController pc)
    {
        pc.rb.MovePosition(pc.rb.position + pc.MouseLook.direction.normalized * pc.FlySpeed * Time.fixedDeltaTime);
    }

    public override void OnTriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Island"))
        {
            isOnIsland = true;
        }

        if (other.CompareTag("Breed"))
        {
            isOnBreedingIsland = true;
        }
    }

    public override void Update(PlayerController pc)
    {
        if (Input.GetButtonDown("Jump") && isOnIsland)
        {
            pc.TransitionToState(pc.groundState);
        }
        else if (Input.GetButtonDown("Jump") && isOnBreedingIsland)
        {
            pc.TransitionToState(pc.breedState);
        }

        if (pc.isDead)
        {
            pc.TransitionToState(pc.deadState);
        }
    }
}
