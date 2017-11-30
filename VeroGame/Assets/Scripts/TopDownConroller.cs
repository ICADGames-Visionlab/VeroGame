using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownConroller : MonoBehaviour
{

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
            public static float width = 0.5f;
            public static float height = 0.5f;
        }

        public static class Position
        {
            public static float x = -3.5f;
            public static float y = -3.5f;
        }
    }

    GameObject background;
    Mapa.Jogador jogador;

    Mapa mapa;
    Mapa.Position destino;

    public GameObject soundSystem;
    private GameObject soundInstance;

    // Use this for initialization
    void Start()
    {
        LoadBackground();
        LoadObjetos();
        LoadJogador();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 cordenadaMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Mapa.Position cordenadaMapa = getCordenadaMapa(cordenadaMundo);

            if (mapa.inMatrix(cordenadaMapa) && mapa.isAndavel(cordenadaMapa))
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
                Vector3 jogadorSize = jogador.gameObject.GetComponent<Renderer>().bounds.size;
                jogador.gameObject.transform.position = getCordenadaMundo(jogador.position) + (new Vector3(0, jogadorSize.y, 0) / 2.7f);
                destino = jogador.getProximaAcaoDestino();
                if(destino == null)
                    jogador.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
            }

            if (destino != null)
            {
                jogador.movendo = true;
                jogador.gameObject.GetComponent<Animator>().SetBool("IsWalking", true);

                Vector3 jogadorSize = jogador.gameObject.GetComponent<Renderer>().bounds.size;
                Vector3 velocity = Vector3.zero;
                Vector3 newDest = (new Vector3(0, jogadorSize.y, 0) / 2.7f) + getCordenadaMundo(destino);

                Vector2 movementVector = new Vector2(newDest.x - getCordenadaMundo(jogador.position).x, newDest.y - getCordenadaMundo(jogador.position).y);
                print(movementVector);

                //jogador.gameObject.transform.position = new Vector3(jogador.gameObject.transform.position.x + movementVector.x / jogador.velocidade, jogador.gameObject.transform.position.y + movementVector.y / jogador.velocidade, jogador.gameObject.transform.position.z);
                jogador.gameObject.transform.position = Vector3.Lerp(jogador.gameObject.transform.position, newDest, 0.1f);
                
                if (jogador.gameObject.transform.position == newDest)
                {
                    jogador.movendo = false;
                    jogador.position = destino;
                    //jogador.gameObject.transform.position = getCordenadaMundo(jogador.position) + (new Vector3(0, jogadorSize.y, 0) / 2.7f);
                }
            }

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
        mapa = new Mapa(new Vector2(10, 10));//TODO - encontrar o tamanho do mapa baseado no tile size e o size do background

        AudioClip soundClip = Resources.Load(DataStorage.cenaAtual.soundClip) as AudioClip;
        if (soundClip != null)
        {
            GameObject soundInstance = Instantiate(soundSystem);
            soundInstance.GetComponent<SoundSystem>().setClip(soundClip);
            soundInstance.GetComponent<SoundSystem>().setLoop(true);
            //soundInstance.GetComponent<SoundSystem>().playClip();
        }

        /*for (int x = 0; x < (int)mapa.size.x; x++)
        {
            for (int y = 0; y < (int)mapa.size.y; y++)
            {
                float px = Isomatrix.Position.x + x * Isomatrix.Tile.width;
                float py = Isomatrix.Position.y + y * Isomatrix.Tile.height;

                float vx1 = px;float vy1 = py;
                float vx2 = px;float vy2 = py + Isomatrix.Tile.height;

                float hx1 = px;float hy1 = py;
                float hx2 = px + Isomatrix.Tile.width;float hy2 = py;

                Vector2 point_vx1;
                Vector2 point_vx2;
                point_vx1 = PointToIsometric(new Vector2(vx1, vy1));
                point_vx2 = PointToIsometric(new Vector2(vx2, vy2));

                Vector2 point_hx1;
                Vector2 point_hx2;
                point_hx1 = PointToIsometric(new Vector2(hx1, hy1));
                point_hx2 = PointToIsometric(new Vector2(hx2, hy2));

                DrawLine(new Vector3(point_vx1.x, point_vx1.y, 1), new Vector3(point_vx2.x, point_vx2.y, 1), Color.black);
                DrawLine(new Vector3(point_hx1.x, point_hx1.y, 1), new Vector3(point_hx2.x, point_hx2.y, 1), Color.black);
            }
        }*/
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

            Vector3 jogadorSize = jogador.GetComponent<Renderer>().bounds.size;

            this.jogador.gameObject.transform.position = getCordenadaMundo(this.jogador.position) + new Vector3(0, jogadorSize.y, 0) / 2.7f ;
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

    public Vector3 getCordenadaMundo(Mapa.Position position)
    {
        Vector2 temp = MatrixToPoint(new Vector2(position.x, position.y));
        return PointToIsometric(temp);
    }

    public Mapa.Position getCordenadaMapa(Vector3 position)
    {
        Vector2 temp = IsometricToPoint(position);
        temp = PointToMatrix(temp);
        return new Mapa.Position((int)temp.x, (int)temp.y + 9);
    }

    public Vector2 IsometricToPoint(Vector3 position)
    {
        Vector2 point = new Vector2(0, 0);

        point.x = (Isomatrix.Projection.r * (Isomatrix.Projection.r + Isomatrix.Projection.dy) * position.y + (Isomatrix.Projection.r + Isomatrix.Projection.dx) * position.x) / (Mathf.Pow(Isomatrix.Projection.r, 2) + 1);
        point.y = (-Isomatrix.Projection.r * (Isomatrix.Projection.r + Isomatrix.Projection.dx) * position.x + (Isomatrix.Projection.r + Isomatrix.Projection.dy) * position.y) / (Mathf.Pow(Isomatrix.Projection.r, 2) + 1);

        return point;
    }

    public Vector3 PointToIsometric(Vector2 position)
    {
        Vector3 point = new Vector3(0, 0, 1);

        point.x = ((position.x - position.y * Isomatrix.Projection.r) / (Isomatrix.Projection.r + Isomatrix.Projection.dx));
        point.y = ((position.y + position.x * Isomatrix.Projection.r) / (Isomatrix.Projection.r + Isomatrix.Projection.dy));

        return point;
    }

    public Vector2 MatrixToPoint(Vector2 position)
    {
        Vector2 point = new Vector2(0, 0);

        point.x = Isomatrix.Position.x + position.x * Isomatrix.Tile.width;
        point.y = Isomatrix.Position.y + position.y * Isomatrix.Tile.height;

        return point;
    }

    public Vector2 PointToMatrix(Vector2 position)
    {
        Vector2 point = new Vector2(0, 0);

        point.x = Mathf.Floor((position.x - Isomatrix.Position.x) / Isomatrix.Tile.width);
        point.y = Mathf.Floor((position.y - Isomatrix.Projection.r) / Isomatrix.Tile.height);

        return point;
    }

    //---------DEUBG-----------
    //void DrawRectangle(Rect rectangle)
    /*void DrawRectangle(float size, int x, int y, Vector2 pos)
    {

        
        float ang = 1.75f;
        float wisze = ang / 2;
        
        float ang_size = size * ang;



        DrawLine(new Vector3(pos.x + x * wisze + ((y) * ang_size), pos.y + (y) * size, 1),
                new Vector3(pos.x + x * wisze + ((y + 1) * ang_size), pos.y + (y - 1) * size, 1),
                Color.black);

        DrawLine(new Vector3(pos.x + x * wisze + ((y) * ang_size),  pos.y + (y) * size, 1), 
                         new Vector3(pos.x + x * wisze + ((y + 1) * ang_size),  pos.y + (y + 1) * size, 1),
                         Color.black);

    }*/

     void DrawRectangle(Rect rectangle)
     {
         DrawLine(new Vector3(rectangle.x, rectangle.y, 1), new Vector3(rectangle.x + rectangle.width, rectangle.y, 1), Color.black);
         DrawLine(new Vector3(rectangle.x, rectangle.y, 1), new Vector3(rectangle.x, rectangle.y + rectangle.height, 1), Color.black);
         DrawLine(new Vector3(rectangle.x, rectangle.y + rectangle.height, 1), new Vector3(rectangle.x + rectangle.width, rectangle.y + rectangle.height, 1), Color.black);
         DrawLine(new Vector3(rectangle.x + rectangle.width, rectangle.y, 1), new Vector3(rectangle.x + rectangle.width, rectangle.y + rectangle.height, 1), Color.black);
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
