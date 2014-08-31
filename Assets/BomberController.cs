using UnityEngine;
using System.Collections;

public class BomberController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (new Vector3((float)0, (float)5.0, (float)0));
	}
}
