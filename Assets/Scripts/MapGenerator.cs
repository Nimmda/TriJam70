using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public Transform Player;
    private float elapsed = 0f;
    public float NextMapSpawn = 3f;
    public float MapOffset = 15f;
    public GameObject MapPrefab;
    public GameObject[] SpawnPositions;

    public GameObject[] Objects;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < SpawnPositions.Length; i++)
        {
            int rand = Random.Range(0, Objects.Length);

            Vector3 v;

            // generate a random euler angle
            v.x = 0f; // Random.Range(0.0f, 360.0f);
            v.y = 0f; //Random.Range(0.0f, 360.0f);
            v.z = Random.Range(0.0f, 360.0f);

            // convert the euler into a quaternion
            Quaternion q = Quaternion.Euler(v);

            Instantiate(Objects[rand], SpawnPositions[i].transform.position, q);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsed > NextMapSpawn)
        {

            Instantiate(MapPrefab, Player.transform.position, Quaternion.identity);
            elapsed = 0f;
        }

        elapsed += Time.deltaTime;
    }


}
