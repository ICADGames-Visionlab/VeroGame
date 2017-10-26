using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricController : MonoBehaviour {

    public static class Isomatrix
    {
        public static class Projection
        {
            public static float r = 1;
            public static float dx = 0.2f;
            public static float dy = 1.1f;
        }

        public static class Tile
        {
            public static float width = 29;
            public static float height = 29;
        }

        public static class Position
        {
            public static float x = 626;
            public static float y = -12;
        }
    }

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
            Mapa.Position destino = jogador.getProximaAcaoDestino();
            if (destino != null)
                MoveTo(jogador, jogador.position, destino);

            //atualizarJogador();

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
        Mapa.Position jogadorPos = new Mapa.Position((int)DataStorage.cenaAtual.jogador.x, (int)DataStorage.cenaAtual.jogador.y);
        if (jogador != null)
        {
            jogador = Instantiate(jogador);

            this.jogador = new Mapa.Jogador(jogador, jogadorPos, mapa);

            this.jogador.gameObject.transform.position = getCordenadaMundo(this.jogador.position);
        }
    }


    public void createObjeto(DataStorage.CenaAtual.ObjetosCena cenaObjeto)
    {
        Mapa.Position position = new Mapa.Position((int)cenaObjeto.x, (int)cenaObjeto.y);
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

    public void MoveTo(Mapa.Jogador jogador, Mapa.Position origem, Mapa.Position destino)
    {
        Vector3 origemMundo = getCordenadaMundo(origem);
        Vector3 destinoMundo = getCordenadaMundo(destino);

        Vector2 movementVector = new Vector2(Mathf.Abs(destinoMundo.x - origemMundo.x), Mathf.Abs(destinoMundo.y - origemMundo.y));
        print(movementVector);
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

    public Vector2 IsometricToMatrix(Vector3 position)
    {
        Vector2 point = new Vector2(0, 0);

        point.x = (Isomatrix.Projection.r * (Isomatrix.Projection.r + Isomatrix.Projection.dy) * position.y + (Isomatrix.Projection.r + Isomatrix.Projection.dx) * position.x) / (Mathf.Pow(Isomatrix.Projection.r, 2) + 1);
        point.y = (-Isomatrix.Projection.r * (Isomatrix.Projection.r + Isomatrix.Projection.dx) * position.x + (Isomatrix.Projection.r + Isomatrix.Projection.dy) * position.y) / (Mathf.Pow(Isomatrix.Projection.r, 2) + 1);

        return point;
    }

    public Vector3 MatrixToIsometric(Vector2 position)
    {
        Vector3 point = new Vector3(0, 0, 1);

        point.x = ((position.x - position.y * Isomatrix.Projection.r) / (Isomatrix.Projection.r + Isomatrix.Projection.dx));
        point.y = ((position.y + position.x * Isomatrix.Projection.r) / (Isomatrix.Projection.r + Isomatrix.Projection.dy));

        return point;
    }

    public Vector2 MatrixToPoint(Mapa.Position position)
    {
        Vector2 point = new Vector2(0, 0);

        point.x = Isomatrix.Position.x + position.x * Isomatrix.Tile.width;
        point.y = Isomatrix.Position.y + position.y * Isomatrix.Tile.height;

        return point;
    }

    public Mapa.Position PointToMatrix(Vector2 position)
    {
        Mapa.Position point = new Mapa.Position(0, 0);

        point.x = (int)Mathf.Floor((position.x - Isomatrix.Position.x) / Isomatrix.Tile.width);
        point.y = (int)Mathf.Floor((position.y - Isomatrix.Projection.r) / Isomatrix.Tile.height);

        return point;
    }
}
