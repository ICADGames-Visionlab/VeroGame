using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaController : MonoBehaviour {

    GameObject background;

    // Use this for initialization
    void Start () 
	{
        LoadBackground();
        spawnTriggers();
    }

    List<GameObject> sceneTriggerList = new List<GameObject>();
	
	// Update is called once per frame
	void Update () 
	{
		GameObject lastObjectOnMouse = ObjectMouseOver();

        if (lastObjectOnMouse != null)
        {
            lastObjectOnMouse.GetComponent<Animator>().SetBool("selecionado", true);
            if (Input.GetMouseButtonDown(0))
                GameController.ProgredirEtapa(int.Parse(lastObjectOnMouse.name));

            foreach (GameObject gameObject in sceneTriggerList)
            {
                if(!gameObject.Equals(lastObjectOnMouse))
                    gameObject.GetComponent<Animator>().SetBool("selecionado", false);
            }
        }
        else
        {
            foreach(GameObject gameObject in sceneTriggerList)
            {
                gameObject.GetComponent<Animator>().SetBool("selecionado", false);
            }
        }
	}

    public void LoadBackground()
    {
        background = Resources.Load(DataStorage.cenaAtual.background) as GameObject;
        if (background != null)
        {
            Instantiate(background);
        }
    }

    public void spawnTriggers()
    {
        DataStorage.SceneTrigger[] sceneTriggerList = DataStorage.getAllSceneTrigger();

        if(sceneTriggerList != null)
        {
            foreach (DataStorage.SceneTrigger sceneTrigger in sceneTriggerList)
            {
                Vector3 center = new Vector3(sceneTrigger.x, sceneTrigger.y, 0);
                Vector3 size = new Vector3(sceneTrigger.altura, sceneTrigger.largura, 1);

                CreateSceneTrigger(sceneTrigger.sceneId, center, size, sceneTrigger.triggerPath);
            }
        }
        
    }

	public GameObject ObjectMouseOver()
	{
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }
        
		return null;
	}

    public void CreateSceneTrigger(int cenaId, Vector3 center, Vector3 size, string gameObjectPath)
    {
        GameObject prefabInstance = Resources.Load(gameObjectPath) as GameObject;

        GameObject instance = Instantiate(prefabInstance);
        instance.name = cenaId.ToString();
        instance.transform.position = center;

        sceneTriggerList.Add(instance);

        //BoxCollider collider = instance.AddComponent<BoxCollider>();
        //collider.center = center;
        //collider.size = size;
    }
}
