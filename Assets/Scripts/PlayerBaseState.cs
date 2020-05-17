using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void Enter(PlayerController playerController);

    public abstract void Exit(PlayerController playerController);

    public abstract void Update(PlayerController playerController);

    public abstract void FixedUpdate(PlayerController playerController);

    public virtual void OnTriggerEnter(Collider2D other)
    {

    }

}
