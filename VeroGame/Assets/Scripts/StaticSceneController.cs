using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticSceneController : MonoBehaviour {

	public DataStorage.SceneType sceneType;
	public int sceneId;
    public GameObject background;

    // Use this for initialization
    void Start () 
	{
        LoadBackground();
        spawnTriggers();
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
		SceneManager.LoadScene("Scenes/" + sceneName);	
	}

    public void LoadBackground()
    {
        Instantiate(background);
    }

    public void spawnTriggers()
    {
        Scene scene = SceneManager.GetActiveScene();
        List<DataStorage.SceneTrigger> sceneTriggerList = DataStorage.getSceneTrigger_ofScene(scene.name);

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
