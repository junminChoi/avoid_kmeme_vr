using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class memesCamera : MonoBehaviour
{
    public GameObject maincam;
    public GameObject dddj;
    public GameObject cube;
    public GameObject canvas;
    public GameObject head;
    private float moveSpeed = 6.0f;
    private float runSpeed = 10.0f;
    private float positionX = 0.0f;
    private float accel = 0.5f;
    private float SongTimer = 0.0f;
    private bool dddjOn = false, dddjOn2 = false;
    private int sceneNum;
    private bool inst = false;
    private float colisionTime = 0.0f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpeedUp());
    }
    
    // Update is called once per frame
    void Update()
    {
        if (MainSceneCameraMove.Health < 1)
        {
            SceneManager.LoadScene(0);
        }
        MainSceneCameraMove.FullGameTime += Time.deltaTime;
        SongTimer += Time.deltaTime;
        positionX = this.transform.position.x - maincam.transform.rotation.z * moveSpeed / 30.0f;
        this.transform.position = new Vector3(positionX, this.transform.position.y, this.transform.position.z);
        Run();
        if(SongTimer > 6.0f && !dddjOn)
        {
            dddjOn = true;
            dddj.transform.position = new Vector3(0.0f, 7.0f, 75.0f);
            Debug.Log("dddg~");
        }
        if(SongTimer > 8.5f && !dddjOn2)
        {
            dddjOn2 = true;
            dddj.transform.position = new Vector3(6.0f, 7.0f, 120.0f);
            Debug.Log("dddg~");
        }
        if(SongTimer > 50.0f)
        {
            if (!inst)
            {
                Instantiate(cube).transform.parent = head.transform;
                
            }
            cube.transform.position = head.transform.position;
        }
        if(SongTimer > 52.0f)
        {
            if (!inst)
            {
                Instantiate(canvas).transform.parent = maincam.transform;
                inst = true;
            }
            canvas.transform.position = head.transform.position;
        }
        if(SongTimer > 55.0f)
        {
            sceneNum = Random.Range(1, 5);
            if (sceneNum == 2)
            {
                sceneNum++;
            }
            SceneManager.LoadScene(sceneNum);
        }


       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name != "Ground" && (SongTimer-colisionTime) > 2 && collision.gameObject.name != "Cube(Clone)")
        {
            MainSceneCameraMove.Health--;
            Debug.Log("health left : " + MainSceneCameraMove.Health);
            colisionTime = SongTimer;

        }
    }
    void Run()
    {
        this.transform.position += this.transform.forward * runSpeed * Time.deltaTime;

    }
    IEnumerator SpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            runSpeed += accel;
        }

    }
}


