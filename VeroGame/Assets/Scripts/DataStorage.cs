using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataStorage : MonoBehaviour
{
    [Serializable]
    public class CenaAtual
    {
        [Serializable]
        public class ObjetosCena
        {
            public int positionX;
            public int positionY;
            public int dimensionX;
            public int dimensionY;
            public int sceneId = 0;
            public string gameObjectPath;
        }

        [Serializable]
        public class Jogador
        {
            public int positionX;
            public int positionY;
            public int dimensionX;
            public int dimensionY;
            public string gameObjectPath;
        }

        public Processo[] listaProcesso;
        public Nivel[] listaNivel;
        public Case[] listaCase;
        public SceneTrigger[] listaSceneTrigger;
        public string cenaNome;
        public string background;
        public ObjetosCena[] objetosCena;
        public Jogador jogador;
    }

    [Serializable]
    public class Processo
    {
        public int id;
        public string nome;
    }

    [Serializable]
    public class Nivel
    {
        public int id;
        public string nome;
    }

    [Serializable]
    public class Case
    {
        public int id;
        public string nome;
        public Pergunta[] listaPergunta;

        public List<Pergunta> getPerguntasValidas()
        {
            List<Pergunta> perguntasValidas = new List<Pergunta>();

            foreach(Pergunta pergunta in listaPergunta)
            {
                if (pergunta.listaUsuarioResposta.Length != 0)
                    perguntasValidas.Add(pergunta);
            }

            return perguntasValidas;
        }
    }

    [Serializable]
    public class Pergunta
    {
        public int id;
        public int positionX;
        public int positionY;
        public int dimensionX;
        public int dimensionY;
        public string texto;
        public Resposta[] listaResposta;
        public UsuarioResposta[] listaUsuarioResposta;

        public List<Resposta> getRespostas()
        {
            List<Resposta> respostas = new List<Resposta>();

            foreach (Resposta resposta in listaResposta)
            {
                respostas.Add(resposta);
            }

            return respostas;
        }

        public List<UsuarioResposta> getUsuarioRespostas()
        {
            List<UsuarioResposta> usuarioRespostas = new List<UsuarioResposta>();

            foreach (UsuarioResposta usuarioResposta in listaUsuarioResposta)
            {
                usuarioRespostas.Add(usuarioResposta);
            }

            return usuarioRespostas;
        }
    }

    [Serializable]
    public class Resposta
    {
        public int id;
        public string texto;
        public int tipo;
        public int positionX;
        public int positionY;
        public int dimensionX;
        public int dimensionY;
        public string marcadorPath;
    }

    [Serializable]
    public class UsuarioResposta
    {
        public int respostaId;
        public int caseId;
    }

    [Serializable]
    public class SceneTrigger
    {
        public int sceneId;
        public float x;
        public float y;
        public float altura;
        public float largura;
    }

    public static CenaAtual cenaAtual;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void LoadCenaData()
    {
        string json = System.IO.File.ReadAllText(GameController.getEtapaFileString());

        cenaAtual = JsonUtility.FromJson<CenaAtual>(json);
    }

    public static SceneTrigger[] getAllSceneTrigger()
    {
        return cenaAtual.listaSceneTrigger;
    }

    public static string getCenaNome()
    {
        return cenaAtual.cenaNome;
    }

    public static Processo getProcesso(int id)
    {
        foreach(Processo processo in cenaAtual.listaProcesso)
            if (processo.id == id)
                return processo;

        return null;
    }

    public static Nivel getNivel(int id)
    {
        foreach (Nivel nivel in cenaAtual.listaNivel)
            if (nivel.id == id)
                return nivel;

        return null;
    }

    public static Case getCase(int id)
    {
        foreach (Case _case in cenaAtual.listaCase)
            if (_case.id == id)
                return _case;

        return null;
    }

    public static CenaAtual.ObjetosCena[] getObjetosCena()
    {
        return cenaAtual.objetosCena;
    }
}