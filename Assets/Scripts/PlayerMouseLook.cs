using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{

    private Quaternion rotationPlayer;

    public float Speed = 5f;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1));
        direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x);

        rotationPlayer = Quaternion.AngleAxis(angle * Mathf.Rad2Deg - 90f, Vector3.forward);
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationPlayer, Speed * Time.fixedDeltaTime);
    }
}
