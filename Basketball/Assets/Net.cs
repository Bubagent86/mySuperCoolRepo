using UnityEngine;
using System.Collections;

public class Net : MonoBehaviour {
	public ParticleSystem partSys;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		partSys.Play ();

	}
		
}
