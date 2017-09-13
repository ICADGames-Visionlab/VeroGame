using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseScene : MonoBehaviour {

    public int caseId;
    public GameObject background;

	// Use this for initialization
	void Start () {
        LoadBackground();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadBackground()
    {
        Instantiate(background);
    }
}
