using UnityEngine;
using System.Collections;

public class CameraSmoothMove : MonoBehaviour {

	public Transform targetTransform = null;
	public float smoothTime = 0.3f;
	private Vector3 velocity = Vector3.zero; 


	private float distance = 0;

	// Use this for initialization
	void Start () {
	
		if (this.targetTransform == null)
			this.targetTransform = GameObject.Find("Player").transform;

	}

	// Update is called once per frame
	void Update () {
		float xPT = Mathf.SmoothDamp( this.transform.position.x, 
		                                             targetTransform.position.x, ref velocity.x, smoothTime);
		float zPT = Mathf.SmoothDamp( this.transform.position.z, 
		                                             targetTransform.position.z, ref velocity.z, smoothTime);

		this.transform.position = new Vector3(xPT, this.transform.position.y, zPT);
	}
}
