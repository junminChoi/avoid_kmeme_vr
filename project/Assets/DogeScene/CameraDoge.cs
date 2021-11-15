using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraDoge : MonoBehaviour
{
    public GameObject Doge;
    public GameObject Cam;
    private float demageTimer, dogeTimer;
    private float runspeed = 3.0f;
    private float gameTime;
    private bool dogeInst = false;
    private int scenenums;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        
        ray = new Ray();
        ray.origin = this.transform.position;
        demageTimer = 0.0f;
        dogeTimer = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        MainSceneCameraMove.FullGameTime += Time.deltaTime;
        if (MainSceneCameraMove.Health < 1)
        {
            SceneManager.LoadScene(0);
        }
        gameTime += Time.deltaTime;
        ray.direction = this.transform.forward;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        RaycastHit hit;
        demageTimer += Time.deltaTime;
        dogeTimer += Time.deltaTime;
        
        Doge.transform.position = Vector3.MoveTowards(Doge.transform.position, ray.direction * 10 , Time.deltaTime * runspeed);

        if(dogeTimer > 10 && !dogeInst)
        {
            runspeed = 7.0f;
            dogeInst = true;
        }
        if (Physics.Raycast(this.transform.position,forward, out hit))
        {
            if (hit.transform.gameObject.name == "Planet(Clone)" || hit.transform.gameObject.name == "Doge")
            {
                if(demageTimer > 2)
                {
                    Debug.Log("펑!");
                    MainSceneCameraMove.Health--;
                    Debug.Log("Health left : " + MainSceneCameraMove.Health);
                    demageTimer = 0.0f;
                }
                
            }
        }

        if(gameTime > 30.0f)
        {
            scenenums = Random.Range(1, 5);
            if(scenenums == 1)
            {
                scenenums++;
            }
            SceneManager.LoadScene(scenenums);
        }
    }

    
}
