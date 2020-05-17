using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject Finished;
    public GameObject Dead;
    public bool isDead = false;
    public float Health = 100;
    private PlayerBaseState currentState = null;

    public PlayerMouseLook MouseLook;
    public Sprite air, ground;
    public Rigidbody2D rb = null;
    public float Speed = 5f;
    public float FlySpeed = 10f;

    public Vector2 movement = Vector2.zero;

    public readonly PlayerGroundState groundState = new PlayerGroundState();
    public readonly PlayerAirState airState = new PlayerAirState();
    public readonly PlayerDeadState deadState = new PlayerDeadState();
    public readonly PlayerBreedState breedState = new PlayerBreedState();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MouseLook = GetComponent<PlayerMouseLook>();

        currentState = airState;

        StartCoroutine(DecreaseHealthRoutine());
    }

    public IEnumerator DecreaseHealthRoutine()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(1f);
            Health -= 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0f)
        {
            isDead = true;

            PlayerDead();
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        currentState.Update(this);
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate(this);
    }

    public void TransitionToState(PlayerBaseState state)
    {
        if (currentState != null)
        {
            currentState.Exit(this);
        }

        currentState = state;

        currentState.Enter(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentState.OnTriggerEnter(other);
    }


    public void PlayerBreedState()
    {
        Finished.SetActive(true);

    }

    public void PlayerDead()
    {
        Dead.SetActive(true);
    }

}
