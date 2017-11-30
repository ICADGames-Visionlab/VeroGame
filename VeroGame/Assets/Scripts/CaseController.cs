using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseController : MonoBehaviour {
    public class MarcadorResposta
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

            this.gameObject.GetComponent<Animator>().SetBool("marcado", marcado);
        }
    }

    GameObject background;
    List<DataStorage.Pergunta> perguntasCase;
    DataStorage.Case caseAtual;

    public Canvas canvas;
    public Text textPrefab;

    public GameObject soundSystem;
    private GameObject soundInstance;

    List<Text> textList = new List<Text>();
    List<MarcadorResposta> marcadoresList = new List<MarcadorResposta>();
    GameObject btProximo;
    Material btProximoActive;
    Material btProximoOff;

    int indexPerguntaAtual = 0;

	// Use this for initialization
	void Start () {

        MessageSystem.instance.HideAll();

        caseAtual = DataStorage.getCase(GameController.getEtapaId());
        perguntasCase = caseAtual.getPerguntasValidas();

        if (perguntasCase.Count == 0)
        {
            GameController.RegredirEtapa();
            return;
        }
            
        LoadBackground();
        LoadPergunta(perguntasCase[indexPerguntaAtual]);

        btProximo = LoadBotaoProximo(new Vector3(perguntasCase[indexPerguntaAtual].btOK_X, perguntasCase[indexPerguntaAtual].btOK_Y, -1), new Vector2(1, 1), perguntasCase[indexPerguntaAtual].btOK_Path);
        btProximoOff = Resources.Load("Darker") as Material;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject lastObjectOnMouse = ObjectMouseOver();

        if (Input.GetMouseButtonDown(0))
        {
            if(lastObjectOnMouse != null)
            {
                if(lastObjectOnMouse == btProximo)
                {
                    if(CheckRespostaValida())
                        ProximaPergunta();
                }
                else
                {
                    MarcadorResposta marcadorClicado = getMarcadorResposta(lastObjectOnMouse);
                    SelecionarMarcador(marcadorClicado);
                }
            }
        }

        if(btProximo != null)
        {
            if (CheckRespostaValida())
                btProximo.GetComponent<SpriteRenderer>().material = btProximoActive;
            else
                btProximo.GetComponent<SpriteRenderer>().material = btProximoOff;
        }
    }

    public void ProximaPergunta()
    {
        SalvarRespostas();
        clearText();
        clearMarcador();

        indexPerguntaAtual++;
        if (indexPerguntaAtual < perguntasCase.Count)
            LoadPergunta(perguntasCase[indexPerguntaAtual]);
        else
            GameController.RegredirEtapa();
    }

    public void LoadBackground()
    {
        background = Resources.Load(DataStorage.cenaAtual.background) as GameObject;
        if (background != null)
        {
            Instantiate(background);
        }

        AudioClip soundClip = Resources.Load(DataStorage.cenaAtual.soundClip) as AudioClip;
        if (soundClip != null)
        {
            GameObject soundInstance = Instantiate(soundSystem);
            soundInstance.GetComponent<SoundSystem>().setClip(soundClip);
            soundInstance.GetComponent<SoundSystem>().setLoop(true);
            //soundInstance.GetComponent<SoundSystem>().playClip();
        }
    }

    public void SalvarRespostas()
    {
        foreach(MarcadorResposta marcador in marcadoresList)
        {
            if(marcador.marcado)
            {
                DataStorage.UsuarioResposta resposta = new DataStorage.UsuarioResposta(marcador.respostaId, caseAtual.id, marcador.indice);
                string repostaJson = JsonUtility.ToJson(resposta);
                DataStorage.salvarResposta(resposta);
            }
        }
    }

    public void LoadPergunta(DataStorage.Pergunta pergunta)
    {
        List<DataStorage.Resposta> respostas = pergunta.getRespostas();

        LoadText(new Vector3(pergunta.x, pergunta.y, -2), new Vector2(pergunta.largura, pergunta.altura), pergunta.texto);

        foreach (DataStorage.Resposta resposta in respostas)
        {
            LoadResposta(resposta, pergunta.tipo);
        }
    }

    public void LoadResposta(DataStorage.Resposta resposta, int tipoPergunta)
    {
        LoadText(new Vector3(resposta.x, resposta.y, -2), new Vector2(resposta.largura, resposta.altura), resposta.texto);

        if(tipoPergunta == 1)
        {
            LoadMarcadorResposta(new Vector3(resposta.marcadorX[0], resposta.marcadorY[0], -1), new Vector2(resposta.largura, resposta.altura), resposta.id, 1, false, resposta.marcadorPath);
            LoadMarcadorResposta(new Vector3(resposta.marcadorX[1], resposta.marcadorY[1], -1), new Vector2(resposta.largura, resposta.altura), resposta.id, 2, false, resposta.marcadorPath);
        }
    }

    public void LoadMarcadorResposta(Vector3 position, Vector2 dimension, int respostaId, int indice, bool marcado, string gameObjectPath)
    {
        GameObject prefab = Resources.Load(gameObjectPath) as GameObject;

        GameObject instance = Instantiate(prefab);
        instance.transform.position = position;
        //instance.transform.localScale = dimension;

        //AddCollider(instance, new Vector3(dimension.x, dimension.y, 1));

        MarcadorResposta marcador = new MarcadorResposta(respostaId, indice, false, instance);

        marcadoresList.Add(marcador);
    }

    public GameObject LoadBotaoProximo(Vector3 position, Vector2 dimension, string gameObjectPath)
    {
        GameObject prefab = Resources.Load(gameObjectPath) as GameObject;

        GameObject instance = Instantiate(prefab);
        instance.transform.position = position;
        //instance.transform.localScale = dimension;

        //AddCollider(instance, new Vector3(dimension.x, dimension.y, 1));
        btProximoActive = instance.GetComponent<SpriteRenderer>().material;
        return instance;
    }

    public void LoadText(Vector3 position, Vector2 dimension, string text)
    {
        Text newTextInstance = Instantiate(textPrefab);

        newTextInstance.transform.SetParent(canvas.transform);

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

    public bool CheckRespostaValida()
    {
        int maxIndice = -1;
        int respostasMarcadas = 0;

        foreach(MarcadorResposta marcador in marcadoresList)
        {
            if (marcador.indice > maxIndice)
                maxIndice = marcador.indice;

            if(marcador.marcado)
            {
                respostasMarcadas++;
            }
        }

        if (respostasMarcadas == maxIndice)
            return true;
        return false;
    }

    public void SelecionarMarcador(MarcadorResposta marcadorAtual)
    {
        foreach (MarcadorResposta marcador in marcadoresList)
        {
            if (marcador.indice == marcadorAtual.indice)
            {
                marcador.marcado = false;
                marcador.gameObject.GetComponent<Animator>().SetBool("marcado", false);
            }
            else if (marcador.respostaId == marcadorAtual.respostaId)
            {
                marcador.marcado = false;
                marcador.gameObject.GetComponent<Animator>().SetBool("marcado", false);
            }
                
        }

        marcadorAtual.marcado = true;
        marcadorAtual.gameObject.GetComponent<Animator>().SetBool("marcado", true);
    }

    public MarcadorResposta getMarcadorResposta(int respostaId, int indice)
    {
        foreach (MarcadorResposta marcador in marcadoresList)
        {
            if (respostaId == marcador.respostaId && indice == marcador.indice)
            {
                return marcador;
            }
        }

        return null;
    }

    public MarcadorResposta getMarcadorResposta(GameObject gameObject)
    {
        foreach (MarcadorResposta marcador in marcadoresList)
        {
            if (gameObject == marcador.gameObject)
            {
                return marcador;
            }
        }

        return null;
    }

    public GameObject ObjectMouseOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }

        return null;
    }

    public void AddCollider(GameObject gameObject, Vector3 size)
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.size = size;
    }
}
