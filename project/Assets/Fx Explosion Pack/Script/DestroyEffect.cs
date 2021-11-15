using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
	private float timer;
	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);

		timer += Time.deltaTime;
		if(timer > 2)
        {
			Destroy(gameObject);
        }
	}
}
