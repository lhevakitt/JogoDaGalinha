using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jogador : MonoBehaviour
{
    [SerializeField] private Diretor diretor;
    [SerializeField] private float velocidade;
    [SerializeField] private int numeroDoJogador;

    private SpriteRenderer spriteRenderer;
    private Vector3 posicaoInicial;
    private int tempoDePunicao;
    private int atropelamentos;
    private string tagChegada;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();

        this.alterarCor();
        this.ajustarPosicao();

        this.posicaoInicial = this.transform.position;
        this.tagChegada = "Chegada";
        this.tempoDePunicao = 0;
        this.atropelamentos = 0;
    }

    private void Update()
    {
        if (this.tempoDePunicao > 0)
        {
            this.tempoDePunicao = this.tempoDePunicao - 1;
            this.moverParaBaixo();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(this.tagChegada))
            this.diretor.premiarTime(this.gameObject);
        else
            this.diretor.jogadorAtropelado(this.gameObject, collision.tag);

        //Debug.Log(collision.tag);
    }


    private void alterarCor()
    {
        Color cor;

        switch (this.numeroDoJogador)
        {
            case 1:
                cor = new Color(1f, 1f, 0);
                break;

            case 2:
                cor = new Color(0, 0, 1f);
                break;

            default:
                cor = new Color(0, 0.5f, 0);
                break;
        }

        this.spriteRenderer.color = cor;
    }

    private void ajustarPosicao()
    {
        Vector3 posicao = this.transform.position;

        switch (this.numeroDoJogador)
        {
            case 1:
                posicao.x = 7f;
                break;

            case -1:
                posicao.x = -7f;
                break;

            case 2:
                posicao.x = 4.5f;
                break;

            case -2:
                posicao.x = -4.5f;
                break;

            case 3:
                posicao.x = 2f;
                break;

            case -3:
                posicao.x = -2f;
                break;
        }

        this.transform.position = posicao;
    }

    public void moverParaCima()
    {
        if (this.tempoDePunicao > 0)
            return;

        Vector3 posicao = this.transform.position;

        posicao.y = posicao.y + this.velocidade;

        this.transform.position = posicao;
    }

    public void moverParaBaixo()
    {
        Vector3 posicao = this.transform.position;

        posicao.y = posicao.y - this.velocidade;

        if (posicao.y < this.posicaoInicial.y)
            posicao.y = this.posicaoInicial.y;

        this.transform.position = posicao;
    }


    public int getNumeroDoJogador()
    {
        return this.numeroDoJogador;
    }

    public void setNumeroDoJogador(int numero)
    {
        this.numeroDoJogador = numero;
    }

    public int getNumeroDeAtropelamentos()
    {
        return this.atropelamentos;
    }


    public void voltarParaPosicaoInicial()
    {
        this.transform.position = this.posicaoInicial;
        this.atropelamentos = 0;
    }

    public void punirJogador(int tempo)
    {
        this.tempoDePunicao = tempo;
        this.atropelamentos = this.atropelamentos + 1;
    }

}
