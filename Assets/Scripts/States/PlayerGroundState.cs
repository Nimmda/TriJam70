using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{

    private float ResetTime = 2f;
    private float elapsed = 0f;
    public override void Enter(PlayerController pc)
    {
        elapsed = 0f;
        pc.GetComponent<SpriteRenderer>().sprite = pc.ground;

        pc.StartCoroutine(ResetHealthRoutine(pc));
    }

    public override void Exit(PlayerController pc)
    {

    }

    public override void FixedUpdate(PlayerController pc)
    {

        pc.rb.MovePosition(pc.rb.position + pc.movement * pc.Speed * Time.fixedDeltaTime);
    }

    public override void Update(PlayerController pc)
    {
        if (Input.GetButtonDown("Jump"))
        {
            pc.TransitionToState(pc.airState);
        }


    }

    public IEnumerator ResetHealthRoutine(PlayerController pc)
    {
        while (elapsed < ResetTime)
        {
            pc.Health += (ResetTime - elapsed);
            pc.Health = Mathf.Min(pc.Health, 100f);
            elapsed += Time.deltaTime;

            yield return new WaitForSeconds(0.1f);
        }

        elapsed = 0f;
    }
}
