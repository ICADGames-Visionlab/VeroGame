using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricController : MonoBehaviour {

    GameObject background;
    Mapa.Jogador jogador;

    Mapa mapa;

    // Use this for initialization
    void Start()
    {
        LoadBackground();
        LoadObjetos();
        LoadJogador();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cordenadaMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Mapa.Position cordenadaMapa = getCordenadaMapa(cordenadaMundo);

            /*Mapa.AStar_Node destino = mapa.AStar(jogador.position, cordenadaMapa);
            List<Mapa.Position> caminho = destino.gerarCaminho();
            jogador.gerarPlano(caminho);*/
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.CIMA);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.BAIXO);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.ESQUERDA);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.DIREITA);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.CIMA);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.BAIXO);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.ESQUERDA);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            jogador.adicionarAcao(Mapa.Jogador.Acao.DIREITA);
        }

        if (Input.GetKeyDown(KeyCode.P))
            print("{ " + jogador.position.x + " , " + jogador.position.y + " }");

        if (jogador != null)
        {
            jogador.doProximaAcao();
            atualizarJogador();

            int proximaEtapa = mapa.isProgressao(jogador.position);
            if (proximaEtapa > 0)
            {
                GameController.ProgredirEtapa(proximaEtapa);
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
        mapa = new Mapa(new Vector2(20, 20));//TODO - encontrar o tamanho do mapa baseado no tile size e o size do background
    }

    public void LoadObjetos()
    {
        foreach (DataStorage.CenaAtual.ObjetosCena cenaObjeto in DataStorage.getObjetosCena())
        {
            createObjeto(cenaObjeto);
        }
    }

    public void LoadJogador()
    {
        GameObject jogador = Resources.Load(DataStorage.cenaAtual.jogador.gameObjectPath) as GameObject;
        Mapa.Position jogadorPos = new Mapa.Position(DataStorage.cenaAtual.jogador.x, DataStorage.cenaAtual.jogador.y);
        if (jogador != null)
        {
            jogador = Instantiate(jogador);

            this.jogador = new Mapa.Jogador(jogador, jogadorPos, mapa);

            this.jogador.gameObject.transform.position = getCordenadaMundo(this.jogador.position);
        }
    }


    public void createObjeto(DataStorage.CenaAtual.ObjetosCena cenaObjeto)
    {
        Mapa.Position position = new Mapa.Position(cenaObjeto.x, cenaObjeto.y);
        Vector2 dimension = new Vector2(cenaObjeto.largura, cenaObjeto.altura);
        GameObject objeto = Resources.Load(cenaObjeto.gameObjectPath) as GameObject;
        if (objeto != null)
        {
            objeto = Instantiate(objeto);
            objeto.transform.position = getCordenadaMundo(position);

        }

        for (int x = position.x; x < (int)(position.x + dimension.x); x++)
        {
            for (int y = position.y; y < (int)(position.y + dimension.y); y++)
            {
                if (cenaObjeto.sceneId != 0)
                    mapa.matrix[x, y] = cenaObjeto.sceneId;
                else
                    mapa.matrix[x, y] = -1;
            }
        }
    }

    public void atualizarJogador()
    {
        jogador.gameObject.transform.position = getCordenadaMundo(jogador.position);
    }

    public Vector3 getCordenadaMundo(Mapa.Position position)
    {
        //TODO - tranformar posição matrix em cordenadas do mundo
        return new Vector3(position.x, position.y, 1);
    }

    public Mapa.Position getCordenadaMapa(Vector3 position)
    {
        //TODO - tranformar posição mundo em posicao matrix
        return new Mapa.Position((int)position.x, (int)position.y);
    }
}
