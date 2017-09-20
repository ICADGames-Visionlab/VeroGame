﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour {

	public class Position
	{
		public int x;
		public int y;
		
		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public bool ehIgual(Position pos)
		{
			if(this.x == pos.x && this.y == pos.y)
				return true;
			else
				return false;
		}
	}

    public class Jogador
    {
        public enum Acao
        {
            VAZIO,
            CIMA,
            BAIXO,
            ESQUERDA,
            DIREITA
        }

        public GameObject gameObject;
        public Position position;
        public List<Acao> plano;
        public Mapa mapa;

        public void OnDestroy()
        {
            Camera.main.transform.parent = null;
        }

        public Jogador(GameObject jogador, Position position, Mapa mapa)
        {
            gameObject = jogador;
            this.position = position;
            this.mapa = mapa;
            plano = new List<Acao>();
            Camera.main.transform.parent = gameObject.transform;
        }

        public void adicionarAcao(Acao acao)
        {
            plano.Clear();
            plano.Add(acao);
        }

        public void gerarPlano(List<Position> caminho)
        {
            List<Acao> novoPlano = new List<Acao>();

            foreach(Position positionAtual in caminho)
            {
                int indexAtual = caminho.IndexOf(positionAtual);
                if(indexAtual + 1 < caminho.Count)
                {
                    Position destino = caminho[indexAtual + 1];
                    int xDif = positionAtual.x - destino.x;
                    int yDif = positionAtual.y - destino.y;

                    if (xDif == 1)
                        novoPlano.Add(Jogador.Acao.ESQUERDA);
                    else if (xDif == -1)
                        novoPlano.Add(Jogador.Acao.DIREITA);
                    else if (yDif == 1)
                        novoPlano.Add(Jogador.Acao.CIMA);
                    else if (yDif == -1)
                        novoPlano.Add(Jogador.Acao.BAIXO);
                }
            }

            plano = novoPlano;
        }

        Acao getProximaAcao()
        {
            if (plano.Count == 0)
                return Acao.VAZIO;
            else
            {
                Acao acao = plano[0];
                plano.RemoveAt(0);
                return acao;
            }
        }

        public void doProximaAcao()
        {
            Acao acao = getProximaAcao();

            switch (acao)
            {
                case Acao.VAZIO:
                    return;
                case Acao.CIMA:
                    if ( mapa.isAndavel( new Position(position.x, position.y - 1) ) )
                        position.y = position.y - 1;
                    return;
                case Acao.BAIXO:
                    if ( mapa.isAndavel( new Position(position.x, position.y + 1) ) )
                        position.y = position.y + 1;
                    return;
                case Acao.DIREITA:
                    if ( mapa.isAndavel( new Position(position.x + 1, position.y) ) )
                        position.x = position.x + 1;
                    return;
                case Acao.ESQUERDA:
                    if ( mapa.isAndavel( new Position(position.x - 1, position.y) ) )
                        position.x = position.x - 1;
                    return;
            }
        }
    }

    public class AStar_Node
	{
		public Position pos;
		public int custoAcumulado;
		public int custoTotal;
		public AStar_Node pai;

		public AStar_Node(Position pos, AStar_Node pai, int custoAtual, int custoHeuristica)
		{
			this.pos = pos;
			this.pai = pai;
			if(pai != null)
				this.custoAcumulado = pai.custoAcumulado + custoAtual;
			else
				this.custoAcumulado = 0;

			this.custoTotal = this.custoAcumulado + custoHeuristica;
		}

		public List<Position> gerarCaminho()
		{
			List<Position> caminho = new List<Position>();
			AStar_Node currentNode = this;

			while(currentNode.pai != null)
			{
				caminho.Insert(0, currentNode.pos);
				currentNode = currentNode.pai;
			}

			return caminho;
		}
	}

	public class AStar_Node_List
	{
		public List<AStar_Node> nodeList;

		public AStar_Node_List()
		{
			nodeList = new List<AStar_Node>();
		}

		public void addNode(AStar_Node newNode)
		{
			foreach(AStar_Node node in nodeList)
			{
				if(newNode.custoTotal < node.custoTotal)
				{
					int nodeIndex = nodeList.IndexOf(node);
					nodeList.Insert(nodeIndex, newNode);
					return;
				}
			}

			nodeList.Add(newNode);
		}

		public bool hasNode(Position pos)
		{
			foreach(AStar_Node node in nodeList)
			{
				if(node.pos.ehIgual(pos))
					return true;
			}

			return false;
		}

	}

	public int[,] matrix;
	public Vector2 size;

	public Mapa(Vector2 size)
	{
		this.size = size;
		this.matrix = new int[(int)this.size.x, (int)this.size.y];

		for (int x = 0; x < (int)size.x; x++)
        {
            for (int y = 0; y < (int)size.y; y++)
            {
                matrix[x, y] = 0;
            }
        }
	}

	public int[,] getMapaMatrix()
    {
        return matrix;
    }

	public void printMatrix()
    {
        string line = "";

        for (int x = 0; x < (int)size.x; x++)
        {
            for (int y = 0; y < (int)size.y; y++)
            {
                line += "\t" + matrix[x, y];
            }
            print(line);
            line = "";
        }
    }

	public int getCusto(Position pos)
	{
		return matrix[pos.x, pos.y];
	}

	public bool isAndavel(Position pos)
	{
        if(inMatrix(pos))
		    if(matrix[pos.x, pos.y] >= 0)
			    return true;
		return false;
	}

    public int isProgressao(Position pos)
    {
        if (inMatrix(pos))
            if (matrix[pos.x, pos.y] >= 0)
                return matrix[pos.x, pos.y];
        return 0;
    }

    public bool inMatrix(Position pos)
    {
        if (pos.x < 0 || pos.x >= size.x || pos.y < 0 || pos.y >= size.y)
            return false;
        return true;
    }

    public Jogador.Acao acaoNecessaria(Position origem, Position destino)
    {
        int xDif = origem.x - destino.x;
        int yDif = origem.y - destino.y;

        if(xDif == 1)
            return Jogador.Acao.ESQUERDA;
        else if (xDif == -1)
            return Jogador.Acao.DIREITA;
        else if (yDif == 1)
            return Jogador.Acao.CIMA;
        else if (yDif == -1)
            return Jogador.Acao.BAIXO;

        return Jogador.Acao.VAZIO;
    }

	List<Position> getExpansion(Position origem)
	{
		List<Position> expansion = new List<Position>();
		int x = (int)origem.x;
		int y = (int)origem.y;

		if(x - 1 >= 0)
			expansion.Add(new Position(x-1, y));
		if(y - 1 >= 0)
			expansion.Add(new Position(x, y-1));
		if(x + 1 <= (int)size.x)
			expansion.Add(new Position(x+1, y));
		if(y + 1 <= (int)size.y)
			expansion.Add(new Position(x, y+1));

		return expansion;
	}

	public List<Position> getVizinhos(Position origem)
	{
		List<Position> expansion = getExpansion(origem);
		List<Position> vizinhos = new List<Position>();

		foreach(Position pos in expansion)
		{
			if(isAndavel(pos))
				vizinhos.Add(pos);
		}

		return vizinhos;
	}

	public AStar_Node AStar(Position origem, Position destino)
	{
		AStar_Node_List fronteira = new AStar_Node_List();
		AStar_Node startNode = new AStar_Node(origem, null, getCusto(origem), manhatamDistance(origem, destino));
		AStar_Node currentNode = null;
		List<Position> vizinhos = null;

		fronteira.addNode(startNode);

		while(fronteira.nodeList.Count > 0)
		{
			currentNode = fronteira.nodeList[0];
			fronteira.nodeList.Remove(currentNode);

			if(currentNode.pos.ehIgual(destino))
				break;

			vizinhos = getVizinhos(currentNode.pos);

			foreach(Position pos in vizinhos)
			{
				if(!fronteira.hasNode(pos) && isAndavel(pos))
				{
					AStar_Node newNode = new AStar_Node(pos, currentNode, getCusto(origem), manhatamDistance(pos, destino));
					fronteira.addNode(newNode);
				}
			}
		}

		return currentNode;
	}
		

	public static int manhatamDistance(Position origem, Position destino)
	{
		return Mathf.Abs(origem.x - destino.x) + Mathf.Abs(origem.y - destino.y);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}