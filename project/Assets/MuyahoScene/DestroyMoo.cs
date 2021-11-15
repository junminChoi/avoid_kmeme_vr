using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroyradish());
    }
    IEnumerator Destroyradish()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            // 체력 빼고 파괴
            MainSceneCameraMove.Health--;
            Debug.Log("health" + MainSceneCameraMove.Health);

            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
