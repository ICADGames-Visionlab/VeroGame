using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTeste : MonoBehaviour {

    public Vector3 initialPos;
    public Vector3 finalPos;

	// Use this for initialization
	void Start () {
        transform.position = initialPos;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = Vector3.zero;

        transform.position = Vector3.SmoothDamp(transform.position, finalPos, ref velocity, 1f);
	}
}
