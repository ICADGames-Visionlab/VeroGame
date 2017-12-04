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
            public float x;
            public float y;
            public float largura;
            public float altura;
            public int sceneId = 0;
            public string gameObjectPath;
        }

        [Serializable]
        public class Jogador
        {
            public float x;
            public float y;
            public float largura;
            public float altura;
            public string gameObjectPath;
            public string sfx;
            public int sfxLoop = 0;
        }

        public SceneTrigger[] listaSceneTrigger;
        public string cenaNome;
        public string background;
        public string soundClip;
        public ObjetosCena[] objetosCena;
        public Jogador jogador;
        public int id;
    }

    [Serializable]
    public class ProcessoData
    {
        public Processo[] listaProcesso;
        public Nivel[] listaNivel;
        public Case[] listaCase;
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
                if (pergunta.listaUsuarioResposta.Length == 0 && isRespostaRegistrada(pergunta.listaResposta))
                {

                    perguntasValidas.Add(pergunta);
                }
                    
            }

            return perguntasValidas;
        }
    }

    [Serializable]
    public class Pergunta
    {
        public int id;
        public float x;
        public float y;
        public float largura;
        public float altura;
        public int tipo;
        public string texto;
        public Resposta[] listaResposta;
        public UsuarioResposta[] listaUsuarioResposta;
        public string btOK_Path;
        public float btOK_X;
        public float btOK_Y;

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
        public float x;
        public float y;
        public float largura;
        public float altura;
        public string marcadorPath;
        public float[] marcadorX;
        public float[] marcadorY;
    }

    [Serializable]
    public class UsuarioResposta
    {
        public int respostaId;
        public int caseId;
        public int tipo;

        public UsuarioResposta(int respostaId, int caseId, int tipo)
        {
            this.respostaId = respostaId;
            this.caseId = caseId;
            this.tipo = tipo;
        }
    }

    [Serializable]
    public class SceneTrigger
    {
        public int sceneId;
        public float x;
        public float y;
        public float altura;
        public float largura;
        public string triggerPath;
        public string sfx;
    }

    public static CenaAtual cenaAtual;
    public static ProcessoData processoData;
    public static List<UsuarioResposta> respostasResgistradas = new List<UsuarioResposta>();
    public static List<int> CasesFinalizados = new List<int>();

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

    public static void LoadProcessoData()
    {
        string json = System.IO.File.ReadAllText("Json/ProcessoData.txt");

        processoData = JsonUtility.FromJson<ProcessoData>(json);
    }

    public static void salvarResposta(UsuarioResposta resposta)
    {
        respostasResgistradas.Add(resposta);
    }

    public static List<UsuarioResposta> getRespostaRegistrada(int respostaId, int caseId)
    {
        List<UsuarioResposta> respostas = new List<UsuarioResposta>();

        foreach(UsuarioResposta resposta in respostasResgistradas)
        {
            if(resposta.respostaId == respostaId && resposta.caseId == caseId)
            {
                respostas.Add(resposta);
            }
        }

        return respostas;
    }

    public static bool isRespostaRegistrada(Resposta[] listaResposta)
    {
        foreach (UsuarioResposta usuarioResposta in respostasResgistradas)
        {
            foreach(Resposta resposta in listaResposta)
            {
                if (usuarioResposta.respostaId == resposta.id)
                    return false;
            }
        }

        return true;
    }

    public static void registrarCaseFinalizado(int id)
    {
        CasesFinalizados.Add(id);
    }

    public static bool isCaseFinalizado(int id)
    {
        return CasesFinalizados.Contains(id);
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
        foreach(Processo processo in processoData.listaProcesso)
            if (processo.id == id)
                return processo;

        return null;
    }

    public static Nivel getNivel(int id)
    {
        foreach (Nivel nivel in processoData.listaNivel)
            if (nivel.id == id)
                return nivel;

        return null;
    }

    public static Case getCase(int id)
    {
        foreach (Case _case in processoData.listaCase)
            if (_case.id == id)
                return _case;

        return null;
    }

    public static CenaAtual.ObjetosCena[] getObjetosCena()
    { 
        return cenaAtual.objetosCena;
    }

    public static String getNomeEtapaAtual(int id)
    {
        GameController.Etapa etapa = GameController.getEtapa();
        switch (etapa)
        {
            case GameController.Etapa.HubNivel:
                return getProcesso(id).nome;

            case GameController.Etapa.HubCase:
                return getNivel(id).nome;

            case GameController.Etapa.Case:
                return getCase(id).nome;

            default:
                return null;
        }
    }

    public static String getNomeEtapaProxima(int id)
    {
        GameController.Etapa etapa = GameController.getEtapa();
        switch (etapa)
        {
            case GameController.Etapa.HubProcesso:
                return getProcesso(id).nome;

            case GameController.Etapa.HubNivel:
                return getNivel(id).nome;

            case GameController.Etapa.HubCase:
                return getCase(id).nome;

            default:
                return null;
        }
    }
}