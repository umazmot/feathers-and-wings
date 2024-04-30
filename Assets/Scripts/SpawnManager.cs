using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject feather;

    private float rangeMin = 30.0f;

    private float rangeMax = 50.0f;

    public GameObject player;

    private FeatherCollection featherScript;

    // Start is called before the first frame update
    void Start()
    {
        featherScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FeatherCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (featherScript.featherCount >= 10)
        {
            return;
        }
        GameObject currentFeather = GameObject.FindGameObjectWithTag("Feather");
        if (currentFeather == null)
        {
            Instantiate(feather, GenerateSpawnPosition(), feather.transform.rotation);
        } else if (currentFeather.transform.position.y > player.transform.position.y + 5.0f)
        {
            Destroy(currentFeather);
            Instantiate(feather, GenerateSpawnPosition(), feather.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(rangeMin, rangeMax);
        float spawnPosY = Random.Range(rangeMin, rangeMax);
        float spawnPosZ = Random.Range(rangeMin, rangeMax);
        int signX = Random.Range(-1, 1) >= 0 ? 1 : -1;
        int signZ = Random.Range(-1, 1) >= 0 ? 1 : -1;
        return new Vector3(
            player.transform.position.x + signX * spawnPosX,
            player.transform.position.y - spawnPosY,
            player.transform.position.z + signZ * spawnPosZ);
    }
}
