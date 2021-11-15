using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCamera : MonoBehaviour
{
    public GameObject can;
    public GameObject canShadow;
    public GameObject Spawner;
    private Vector3 ScreenCenter;
    private float timer, sceneTimer;

    private bool isSpawn = false;
    private Vector3 vectorCan;
    private float hittime;
    private int scenenum;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        timer = 0.0f;
        sceneTimer = 0.0f;
        hittime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit hit;
        MainSceneCameraMove.FullGameTime += Time.deltaTime;

        hittime += Time.deltaTime;
        sceneTimer += Time.deltaTime;
        if(sceneTimer < 10)
        {
            timer += Time.deltaTime;
            if (timer < 1.0f)
            {
                canShadow.transform.position = new Vector3(ray.direction.x, ray.direction.y - 0.2f, ray.direction.z);
            }

            if (timer > 2.0f)
            {
                can.transform.position = canShadow.transform.position;
                timer = 0.0f;
            }
        }
        else
        {
            Destroy(canShadow);
            Destroy(can);
            if (!isSpawn)
            {
                Instantiate(Spawner);
                isSpawn = true;
            }
        }
        if(Physics.Raycast(ray,out hit , 100.0f))
        {
            if (hit.transform.gameObject.name == "TropicanaCan" || hit.transform.gameObject.name == "Apple(Clone)")
            {
                if(hittime > 1)
                {
                    MainSceneCameraMove.Health--;
                    
                    Debug.Log("health left : " + MainSceneCameraMove.Health);
                    hittime = 0;
                }
            }
           
        }

        if(sceneTimer > 23.0f)
        {
            scenenum = Random.Range(1, 5);
            if (scenenum == 4)
            {
                scenenum = 1;
            }
            SceneManager.LoadScene(scenenum);
        }
        if(MainSceneCameraMove.Health < 1)
        {
            SceneManager.LoadScene(0);
        }

    }
}
