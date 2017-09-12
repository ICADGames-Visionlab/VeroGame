using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {

	public enum SceneType
	{
		PROCESSO,
		NIVEL,
		CASE
	}

    public class Processo
    {
        int id;
        string nome;
    }

    public class Nivel
    {
        int id;
        string nome;
    }

    public class Case
    {
        int id;
        string nome;
    }

    public class Pergunta
    {
        int id;
        string texto;
        Resposta[] respostas;
    }

    public class Resposta
    {
        int id;
        string texto;
    }

    public class UsuarioResposta
    {
        int respostaId;
        int caseId;
    }

    public class SceneTrigger
    {
        public string originScene;
        public string targetScene;
        public int id;
        public int x;
        public int y;
        public int altura;
        public int largura;
    }

    static Dictionary<int, SceneTrigger> sceneTriggerStorage;

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
        return sceneTriggerList;
    }
}
