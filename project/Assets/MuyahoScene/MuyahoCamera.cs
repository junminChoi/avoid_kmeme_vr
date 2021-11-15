using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MuyahoCamera : MonoBehaviour
{
    public Image CursorGaugeImage;
    private float GaugeTimer , timer;
    private int scenenum;
    
    GameObject health;
    int healthLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //healthLeft = health.GetComponent<HealthLeft>.health;
    }

    // Update is called once per frame
    void Update()
    {
        MainSceneCameraMove.FullGameTime += Time.deltaTime;
        if (MainSceneCameraMove.Health < 1)
        {
            SceneManager.LoadScene(0);
        }
        timer += Time.deltaTime;
        RaycastHit hit;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (Physics.Raycast(this.transform.position, forward, out hit) && hit.transform.gameObject.name == "Daikon(Clone)")
        {
            GaugeTimer += 1.0f * Time.deltaTime;
            if (GaugeTimer >= 1.0f)
            {

                
                Destroy(hit.transform.gameObject);
                
            }


        }
        else
        {
            GaugeTimer = 0.0f;
        }

        if(timer > 26)
        {
            scenenum = Random.Range(1, 5);
            if (scenenum == 3)
            {
                scenenum++;
            }
            SceneManager.LoadScene(scenenum);
        }
    }
}
