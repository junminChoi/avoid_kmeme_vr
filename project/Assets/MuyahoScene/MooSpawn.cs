using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MooSpawn : MonoBehaviour
{
    public GameObject Moo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMoo());
    }

    // Update is called once per frame
    IEnumerator SpawnMoo()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);

            Vector3 pos = this.transform.position + new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-0.7f, 0.7f), 3);
            Instantiate(Moo, pos, Quaternion.identity);

        }
    }
}
