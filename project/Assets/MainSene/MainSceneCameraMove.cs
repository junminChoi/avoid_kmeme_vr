using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneCameraMove : MonoBehaviour
{
    public Image CursorGaugeImage;
    public Text timeText;
    private float GaugeTimer;
    private float timer;
    private int sceneNum;
    public static int Health;
    public static float FullGameTime;
    public static bool isFirstGame = true;
    // Start is called before the first frame update
    void Start()
    {
        
        Health = 5;   
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        RaycastHit hit;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = GaugeTimer;

        if (Physics.Raycast(this.transform.position, forward, out hit) && hit.transform.gameObject.name == "Start")
        {
            GaugeTimer += 1.0f * Time.deltaTime;
            if (GaugeTimer >= 1.0f)
            {
                Destroy(hit.transform.gameObject);
                sceneNum = Random.Range(1, 5);
                FullGameTime = 0;
                SceneManager.LoadScene(sceneNum);
            }


        }
        else
        {
            GaugeTimer = 0.0f;
        }

        timeText.text = "result Score : " + FullGameTime.ToString() + "Sec";
        Debug.Log("time : " + FullGameTime);
    }
}
