using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownConroller : MonoBehaviour {

    GameObject background;
    GameObject jogador;

    int[,] mapaMatrix;
    Vector2 mapaSize;

	// Use this for initialization
	void Start () {
        LoadBackground();
        LoadObjetos();
        printMapaMatrix();
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
        InitializeMapaMatrix(new Vector2(20, 20));//TODO - encontrar o tamanho do mapa baseado no tile size e o size do background
    }

    public void LoadObjetos()
    {
        foreach (DataStorage.CenaAtual.ObjetosCena cenaObjeto in DataStorage.getObjetosCena())
        {
            createObjeto(cenaObjeto.gameObjectPath, new Vector2(cenaObjeto.positionX, cenaObjeto.positionY), new Vector2(cenaObjeto.dimensionX, cenaObjeto.dimensionY));
        }
    }

    public void LoadJogador()
    {
        jogador = Resources.Load(DataStorage.cenaAtual.jogador.gameObjectPath) as GameObject;
        if (jogador != null)
        {
            jogador = Instantiate(background);
            Vector2 position = new Vector2(DataStorage.cenaAtual.jogador.positionX, DataStorage.cenaAtual.jogador.positionY);
            jogador.transform.position = getTransformedPosition(position);
        }
    }

    public void InitializeMapaMatrix(Vector2 mapaSize)
    {
        this.mapaSize = mapaSize;
        mapaMatrix = new int[(int)mapaSize.x, (int)mapaSize.y];

        for (int x = 0; x < (int)mapaSize.x; x++)
        {
            for (int y = 0; y < (int)mapaSize.y; y++)
            {
                mapaMatrix[x, y] = 0;
            }
        }
    }

    public int[,] getMapaMatrix()
    {
        return mapaMatrix;
    }

    public void printMapaMatrix()
    {
        string line = "";

        for (int x = 0; x < (int)mapaSize.x; x++)
        {
            for (int y = 0; y < (int)mapaSize.y; y++)
            {
                line += "\t" + mapaMatrix[x, y];
            }
            print(line);
            line = "";
        }
    }

    public void createObjeto(string gameObjectPath, Vector2 position, Vector2 dimension)
    {
        GameObject objeto = Resources.Load(gameObjectPath) as GameObject;
        if (objeto != null)
        {
            objeto = Instantiate(objeto);
            objeto.transform.position = getTransformedPosition(position);
            
        }

        for (int x = (int)position.x; x < (int)(position.x + dimension.x); x++)
        {
            for (int y = (int)position.y; y < (int)(position.y + dimension.y); y++)
            {
                mapaMatrix[x, y] = 1;
            }
        }
    }

    public Vector3 getTransformedPosition(Vector2 position)
    {
        //TODO - tranformar posição matrix em cordenadas do mundo
        return new Vector3(position.x, position.y, 1);
    }
}
