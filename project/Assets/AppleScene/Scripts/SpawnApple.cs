using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    public GameObject apple;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAp());
    }

    IEnumerator SpawnAp()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Vector3 pos = this.transform.position + new Vector3(Random.RandomRange(-4.0f, 4.0f), 4, Random.RandomRange(-4.0f, 4.0f));
            Instantiate(apple, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
