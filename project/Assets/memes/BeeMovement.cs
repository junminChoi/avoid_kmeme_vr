using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    private float way;
    private float timer;
    private float positionX;
    // Start is called before the first frame update
    void Start()
    {
        way = 1;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        positionX = 10.0f * Time.deltaTime * way;
        this.transform.position += new Vector3(positionX, 0, 0);
        
        if(timer > 2)
        {
            way = way * -1;
            timer = 0;
        }

    }
}
