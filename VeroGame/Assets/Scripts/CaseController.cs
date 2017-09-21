using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseController : MonoBehaviour {
    class MarcadorResposta
    {
        public int respostaId;
        public int indice;
        public bool marcado;
        public GameObject gameObject;

        public MarcadorResposta(int respostaId, int indice, bool marcado, GameObject gameObject)
        {
            this.respostaId = respostaId;
            this.indice = indice;
            this.marcado = marcado;
            this.gameObject = gameObject;
        }
    }

    GameObject background;
    List<DataStorage.Pergunta> perguntasCase;
    DataStorage.Case caseAtual;

    public Canvas canvas;
    public Text textPrefab;

    List<Text> textList = new List<Text>();
    List<MarcadorResposta> marcadoresList = new List<MarcadorResposta>();

	// Use this for initialization
	void Start () {
        //LoadBackground();
        //caseAtual = DataStorage.getCase(GameController.getEtapaId());
        //perguntasCase = caseAtual.getPerguntasValidas();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadBackground()
    {
        background = Resources.Load(DataStorage.cenaAtual.background) as GameObject;
        if (background != null)
        {
            Instantiate(background);
        }
    }

    public void SalvarRespostas()
    {
        foreach(MarcadorResposta marcador in marcadoresList)
        {
            if(marcador.marcado)
            {

            }
        }
    }

    public void LoadPergunta(DataStorage.Pergunta pergunta)
    {
        List<DataStorage.Resposta> respostas = pergunta.getRespostas();

        LoadText(new Vector3(pergunta.positionX, pergunta.positionY, 1), new Vector2(pergunta.dimensionX, pergunta.dimensionY), pergunta.texto);

        foreach (DataStorage.Resposta resposta in respostas)
        {
            LoadResposta(resposta);
        }
    }

    public void LoadResposta(DataStorage.Resposta resposta)
    {
        LoadText(new Vector3(resposta.positionX, resposta.positionY, 1), new Vector2(resposta.dimensionX, resposta.dimensionY), resposta.texto);

        LoadMarcadorResposta(new Vector3(resposta.positionX, resposta.positionY, 1), new Vector2(resposta.dimensionX, resposta.dimensionY), resposta.id, 1, false, resposta.marcadorPath);
    }

    public void LoadMarcadorResposta(Vector3 position, Vector2 dimension, int respostaId, int indice, bool marcado, string gameObjectPath)
    {
        GameObject prefab = Resources.Load(gameObjectPath) as GameObject;

        GameObject instance = Instantiate(prefab);
        instance.transform.position = position;
        instance.transform.localScale = dimension;

        MarcadorResposta marcador = new MarcadorResposta(respostaId, indice, marcado, instance);

        marcadoresList.Add(marcador);
    }

    public void LoadText(Vector3 position, Vector2 dimension, string text)
    {
        Text newTextInstance = Instantiate(textPrefab);

        newTextInstance.transform.parent = canvas.transform;

        newTextInstance.text = text;
        newTextInstance.rectTransform.localPosition = position;
        newTextInstance.rectTransform.sizeDelta = dimension;

        textList.Add(newTextInstance);
    }

    public void clearMarcador()
    {
        foreach (MarcadorResposta marcador in marcadoresList)
        {
            Destroy(marcador.gameObject);
        }

        marcadoresList.Clear();
    }

    public void clearText()
    {
        foreach(Text text in textList)
        {
            Destroy(text.gameObject);
        }

        textList.Clear();
    }
}
