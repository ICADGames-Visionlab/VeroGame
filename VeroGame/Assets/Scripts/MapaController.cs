using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaController : MonoBehaviour {

    GameObject background;
    public GameObject soundSystem;
    private GameObject soundInstance;

    // Use this for initialization
    void Start () 
	{
        LoadBackground();
        spawnTriggers();

        MessageSystem.instance.setText("Nome da Cena", MessageSystem.instance.Legend);
    }

    List<GameObject> sceneTriggerList = new List<GameObject>();
	
	// Update is called once per frame
	void Update () 
	{
		GameObject lastObjectOnMouse = ObjectMouseOver();

        if (lastObjectOnMouse != null)
        {
            if(!lastObjectOnMouse.GetComponent<Animator>().GetBool("selecionado"))
            {
                playSound(lastObjectOnMouse);
            }

            MessageSystem.instance.setText("OI", MessageSystem.instance.Tooltip);

            lastObjectOnMouse.GetComponent<Animator>().SetBool("selecionado", true);
            if (Input.GetMouseButtonDown(0))
            {
                GameController.ProgredirEtapa(int.Parse(lastObjectOnMouse.name));
                MessageSystem.instance.hideText(MessageSystem.instance.Tooltip);
            }
                

            foreach (GameObject gameObject in sceneTriggerList)
            {
                if(!gameObject.Equals(lastObjectOnMouse))
                {
                    gameObject.GetComponent<Animator>().SetBool("selecionado", false);
                    stopSound(gameObject);
                }
                    
            }
        }
        else
        {
            MessageSystem.instance.hideText(MessageSystem.instance.Tooltip);

            foreach (GameObject gameObject in sceneTriggerList)
            {
                gameObject.GetComponent<Animator>().SetBool("selecionado", false);
                stopSound(gameObject);
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

        AudioClip soundClip = Resources.Load(DataStorage.cenaAtual.soundClip) as AudioClip;
        if(soundClip != null)
        {
            GameObject soundInstance = Instantiate(soundSystem);
            soundInstance.GetComponent<SoundSystem>().setClip(soundClip);
            soundInstance.GetComponent<SoundSystem>().setLoop(true);
            //soundInstance.GetComponent<SoundSystem>().playClip();
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

                CreateSceneTrigger(sceneTrigger.sceneId, center, size, sceneTrigger.triggerPath, sceneTrigger.sfx);
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

    public void CreateSceneTrigger(int cenaId, Vector3 center, Vector3 size, string gameObjectPath, string sfx)
    {
        GameObject prefabInstance = Resources.Load(gameObjectPath) as GameObject;

        GameObject instance = Instantiate(prefabInstance);
        instance.name = cenaId.ToString();
        instance.transform.position = center;

        sceneTriggerList.Add(instance);

        AudioClip soundClip = Resources.Load(sfx) as AudioClip;
        if (soundClip != null)
        {
            GameObject soundInstance = Instantiate(soundSystem, instance.transform);
            soundInstance.GetComponent<SoundSystem>().setClip(soundClip);
        }

        //BoxCollider collider = instance.AddComponent<BoxCollider>();
        //collider.center = center;
        //collider.size = size;
    }

    public void stopSound(GameObject go)
    {
        if (go.transform.childCount > 0)
        {
            SoundSystem system = go.GetComponentInChildren<SoundSystem>();
            if (system != null)
                system.stopClip();
        }
    }

    public void playSound(GameObject go)
    {
        if (go.transform.childCount > 0)
        {
            SoundSystem system = go.GetComponentInChildren<SoundSystem>();
            if (system != null)
                system.playClip();
        }
    }
}
