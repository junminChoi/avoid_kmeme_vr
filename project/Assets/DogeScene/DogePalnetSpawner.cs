using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogePalnetSpawner : MonoBehaviour
{
    public GameObject planet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnDogePlanet());
    }

    // Update is called once per frame
    IEnumerator SpawnDogePlanet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            Vector3 pos = this.transform.position + new Vector3(Random.Range(-20, 20), Random.Range(-10, 10),0);
            Instantiate(planet, pos, Quaternion.identity);
            
        }
    }
}
