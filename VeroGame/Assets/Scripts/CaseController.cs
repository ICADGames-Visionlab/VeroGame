using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseController : MonoBehaviour {
    GameObject background;
    List<DataStorage.Pergunta> perguntasCase;
    DataStorage.Case caseAtual;

	// Use this for initialization
	void Start () {
        LoadBackground();
        caseAtual = DataStorage.getCase(GameController.getEtapaId());
        perguntasCase = caseAtual.getPerguntasValidas();
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
}
