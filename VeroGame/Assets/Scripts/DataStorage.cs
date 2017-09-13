using System;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {

    public enum SceneType
	{
		PROCESSO,
		NIVEL,
		CASE
	}

    [Serializable]
    public class Processo
    {
        int id;
        string nome;
    }

    [Serializable]
    public class Nivel
    {
        int id;
        string nome;
    }

    [Serializable]
    public class Case
    {
        int id;
        string nome;
    }

    [Serializable]
    public class Pergunta
    {
        int id;
        string texto;
        Resposta[] respostas;
    }

    [Serializable]
    public class Resposta
    {
        int id;
        string texto;
    }

    [Serializable]
    public class UsuarioResposta
    {
        int respostaId;
        int caseId;
    }

    [Serializable]
    public class SceneTrigger
    {
        public string originScene;
        public string targetScene;
        public int id;
        public float x;
        public float y;
        public float altura;
        public float largura;
    }

    static Dictionary<int, SceneTrigger> sceneTriggerStorage = new Dictionary<int, SceneTrigger>();

    void Awake()
    {
        SceneTrigger sceneTrigger = JsonUtility.FromJson<SceneTrigger>("{\"originScene\":\"SceneDefault\",\"targetScene\":\"Teste\",\"id\":1,\"x'\":0,\"y\":0,\"altura\":200,\"largura\":200}");
        sceneTriggerStorage.Add(1, sceneTrigger);
    }

    // Use this for initialization
    void Start () {
		DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static List<SceneTrigger> getSceneTrigger_ofScene(string sceneName)
    {
        List<SceneTrigger> sceneTriggerList = new List<SceneTrigger>();
        //TODO - retornar a lista com as sceneTrigger cuja originScene é sceneName
        Dictionary<int, SceneTrigger>.KeyCollection keys = sceneTriggerStorage.Keys;

        print(keys.Count);
        foreach (int key in keys)
        {
            SceneTrigger sceneTrigger = sceneTriggerStorage[key];
            print(sceneTrigger.id);
            if (sceneTrigger.originScene == sceneName)
                sceneTriggerList.Add(sceneTrigger);
        }

        return sceneTriggerList;
    }
}
