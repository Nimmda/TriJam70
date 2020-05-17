using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadState : PlayerBaseState
{
    public override void Enter(PlayerController playerController)
    {
        // SHow ui
    }

    public override void Exit(PlayerController playerController)
    {
        // 
    }

    public override void FixedUpdate(PlayerController playerController)
    {

    }

    public override void Update(PlayerController playerController)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
