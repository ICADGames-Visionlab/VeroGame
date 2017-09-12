using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticSceneController : MonoBehaviour {

	public DataStorage.SceneType sceneType;
	public int sceneId;
    public GameObject background;

    void Awake()
    {
        spawnBackground();
        spawnTriggers();
    }

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
            

            if (lastObjectOnMouse != null)
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

    public void spawnBackground()
    {
        Instantiate(background);
    }

    public void spawnTriggers()
    {
        string sceneName = "TODO - get current scene name";
        List<DataStorage.SceneTrigger> sceneTriggerList = DataStorage.getSceneTrigger_ofScene(sceneName);

        foreach(DataStorage.SceneTrigger sceneTrigger in sceneTriggerList)
        {
            CreateSceneTrigger(sceneTrigger.targetScene, new Vector3(sceneTrigger.x, sceneTrigger.y, 0), new Vector3(sceneTrigger.altura, sceneTrigger.largura, 1));
        }
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

    public void CreateSceneTrigger(string sceneName, Vector3 center, Vector3 size)
    {
        GameObject trigger = new GameObject(sceneName);

        BoxCollider collider = trigger.AddComponent<BoxCollider>();
        collider.center = center;
        collider.size = size;
    }
}
