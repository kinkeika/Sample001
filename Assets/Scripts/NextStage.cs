using UnityEngine;
using System.Collections;

public class NextStage : MonoBehaviour {

	[SerializeField]
	private Transform Player = null;
	[SerializeField]
	private Transform EasyTouch = null;

	void Awake()
	{
		if (Player == null)
			this.Player = GameObject.Find("Player").transform;

		DontDestroyOnLoad(this.Player);
		DontDestroyOnLoad(this.EasyTouch);
	}


	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("collision >>> " + collision.gameObject.name);

		Application.LoadLevel("Battle002");
	}


	void OnTriggerEnter(Collider other)
	{
		Debug.Log("collision >>> " + other.gameObject.name);

		Application.LoadLevel("Battle002");
	}
}
