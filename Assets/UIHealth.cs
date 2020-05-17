using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public PlayerController pc;
    private Text Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Text>();
        Health.text = "Health: " + pc.Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "Health: " + ((int)pc.Health).ToString();
    }
}
