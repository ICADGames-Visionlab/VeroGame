using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownConroller : MonoBehaviour
{

    GameObject background;
    Mapa.Jogador jogador;

    Mapa mapa;
    Mapa.Position destino;

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

            GameObject ellipse1 = GameObject.Find("Ellipse 1");
            ellipse1.transform.SetPositionAndRotation(new Vector3(cordenadaMundo.x, cordenadaMundo.y, 0), ellipse1.transform.rotation);

            GameObject ellipse2 = GameObject.Find("Ellipse 2");
            ellipse2.transform.SetPositionAndRotation(new Vector3(cordenadaMapa.x, cordenadaMapa.y, 0), ellipse2.transform.rotation);




            if (mapa.inMatrix(cordenadaMapa))
            {
                Mapa.AStar_Node destino = mapa.AStar(jogador.position, cordenadaMapa);
                List<Mapa.Position> caminho = destino.gerarCaminho();
                jogador.gerarPlano(caminho);
            }

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
            GameController.ProgredirEtapa(1);

        if (jogador != null)
        {
            if (!jogador.movendo)
            {
                destino = jogador.getProximaAcaoDestino();
            }

            if (destino != null)
            {
                jogador.movendo = true;
                Vector2 movementVector = new Vector2(getCordenadaMundo(destino).x - getCordenadaMundo(jogador.position).x, getCordenadaMundo(destino).y - getCordenadaMundo(jogador.position).y);

                jogador.gameObject.transform.position = new Vector3(jogador.gameObject.transform.position.x + movementVector.x / jogador.velocidade, jogador.gameObject.transform.position.y + movementVector.y / jogador.velocidade, jogador.gameObject.transform.position.z);
                //jogador.gameObject.transform.position = Vector3.Lerp(jogador.gameObject.transform.position, getCordenadaMundo(destino), 0.1F);

                if (jogador.gameObject.transform.position == getCordenadaMundo(destino))
                {
                    jogador.movendo = false;
                    jogador.position = destino;
                    jogador.gameObject.transform.position = getCordenadaMundo(jogador.position);
                }
            }

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
            background = Instantiate(background);
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y, 2);
        }
        mapa = new Mapa(new Vector2(20, 100));//TODO - encontrar o tamanho do mapa baseado no tile size e o size do background
        GameObject tileInstance = Resources.Load("block") as GameObject;


        for (int x = -(int)mapa.size.x; x < (int)mapa.size.x; x++)
        {
            for (int y = 0; y < (int)mapa.size.y; y++)
            {
                DrawRectangle(0.245f, x, y, new Vector2(-9.161f, -5.096f));
            }
        }
        //DrawRectangle(1, 0, 0, new Vector2(3.023f, 1.915f));
    }

    public void LoadObjetos()
    {
        if (DataStorage.getObjetosCena() != null)
        {
            foreach (DataStorage.CenaAtual.ObjetosCena cenaObjeto in DataStorage.getObjetosCena())
            {
                createObjeto(cenaObjeto);
            }
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

    public void MoveTo(Mapa.Position origem, Mapa.Position destino)
    {
        Vector3 origemMundo = getCordenadaMundo(origem);
        Vector3 destinoMundo = getCordenadaMundo(destino);

        Vector2 movementVector = new Vector2(Mathf.Abs(destinoMundo.x - origemMundo.x), Mathf.Abs(destinoMundo.y - origemMundo.y));
    }

    public void atualizarJogador()
    {
        jogador.gameObject.transform.position = getCordenadaMundo(jogador.position);
    }

    public Vector3 getCordenadaMundo(Mapa.Position position)
    {
        //TODO - tranformar posição matrix em cordenadas do mundo
        // Vector3 cordMundo = new Vector3(position.x - 9, position.y - 5 + (position.x * 0.2f), -2);
        Vector3 cordMundo = new Vector3(position.x - 9, position.y - 5, -2);
        return cordMundo;
    }

    public Mapa.Position getCordenadaMapa(Vector3 position)
    {
        //TODO - tranformar posição mundo em posicao matrix
        return new Mapa.Position((int)position.x + 9, (int)position.y + 5);
    }

    //---------DEUBG-----------
    //void DrawRectangle(Rect rectangle)
    void DrawRectangle(float size, int x, int y, Vector2 pos)
    {

        
        float ang = 1.75f;
        float wisze = ang / 2;
        
        float ang_size = size * ang;



        DrawLine(new Vector3(pos.x + x * wisze + ((y) * ang_size), pos.y + (y) * size, 1),
                new Vector3(pos.x + x * wisze + ((y + 1) * ang_size), pos.y + (y - 1) * size, 1),
                Color.black);


        //left ) + ((y + 1) * ang_size)
        //(((x + 1) * size) + ((y + 1) * ang_size)
        DrawLine(new Vector3(pos.x + x * wisze + ((y) * ang_size),  pos.y + (y) * size, 1), 
                         new Vector3(pos.x + x * wisze + ((y + 1) * ang_size),  pos.y + (y + 1) * size, 1),
                         Color.black);
                         
        /*
        float factor = 2f;

        float start_x_left = pos.x + ((x / size) + (y / size)) / factor;
        float start_y_left = pos.y + ((y / size) -  (x  / size)) / factor;

        float end_x_left = pos.x + ((x / size) + ((y + 1)  / size)) / factor;
        float end_y_left = pos.y + (((y + 1) / size) - ((x ) / size)) / factor;
        

        float start_x_bottom = pos.x + ((x / size) + (y  / size)) / factor;
        float start_y_bottom = pos.y + ((y / size) - (x  / size)) / factor;

        float end_x_bottom = pos.x + (((x + 1) / size) + (y  / size)) / factor;
        float end_y_bottom = pos.y + ((y / size) - ((x + 1)  / size)) / factor;

        //left
        DrawLine(new Vector3(start_x_left, start_y_left, 1), new Vector3(end_x_left, end_y_left, 1), Color.black);

        //bottom
        DrawLine(new Vector3(start_x_bottom, start_y_bottom, 1), new Vector3(end_x_bottom, end_y_bottom, 1), Color.black);

        */


    }

    void DrawLine(Vector3 start, Vector3 end, Color color)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.05f, 0.05f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
    }
}
