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

    // Use this for initialization
    void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
