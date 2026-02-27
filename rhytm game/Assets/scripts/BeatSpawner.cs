using System.Collections;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    public GameObject beat;

    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    public IEnumerator StartSpawn()
    {
        while (true)
        {
            GameObject newbeat = Instantiate(beat);
            newbeat.transform.position = new Vector2(Random.value * 20 - 10, Random.value * 10 - 5);
            Destroy(newbeat, 1.5f);
            yield return new WaitForSeconds(1);
        }
    }
}