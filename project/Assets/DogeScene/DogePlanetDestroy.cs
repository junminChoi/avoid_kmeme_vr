using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogePlanetDestroy : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDogePlanet());
    }
        IEnumerator DestroyDogePlanet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            Vector3 vct = this.gameObject.transform.position;
            Destroy(this.gameObject);
            Instantiate(explosion , vct , Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
