using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticSceneController : MonoBehaviour {

	public DataStorage.SceneType sceneType;
	public int sceneId;
    public GameObject Background;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject lastObjectOnMouse = null;
		lastObjectOnMouse = ObjectMouseOver();

		if (Input.GetMouseButtonDown(0))
		{
			if(lastObjectOnMouse != null)
			{
				ChangeScene( lastObjectOnMouse.name );
			}
			else
				print("null");
		}
	}

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);	
	}

	public GameObject ObjectMouseOver()
	{
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hit = new RaycastHit();
         
		if( Physics.Raycast( ray, out hit ) )
		{
			return hit.transform.gameObject;
		}

		return null;
	}
}
