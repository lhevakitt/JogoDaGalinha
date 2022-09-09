using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    [SerializeField] private Sprite spriteCarro;
    [SerializeField] private Sprite spriteCaminhao;
    [SerializeField] private Sprite spriteCaminhaoDuplo;
    [SerializeField] public float velocidade;

    //Parâmetros com valor fixo
    private float percentualSprite1;
    private float percentualSprite2;

    //Variaveis da classe
    private geradorDeCarros gerador;
	private Rigidbody2D rigidbody2d;
    private Renderer renderisador;
    private float tipoDeVeiculo;
    
    private void Awake()
    {
        int cor = 0;
        bool sentidoDoCarro = false;

        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.renderisador = GetComponent<Renderer>();
        this.percentualSprite1 = 3f;
        this.percentualSprite2 = 9f;
        
        this.tipoDeVeiculo = Random.Range(0.0f, 100.0f);
        cor = Random.Range(1, 10);

        sentidoDoCarro = this.sentido();

        this.mudarCor(cor);
        this.mudarSprite();
        this.ajustarSentidoVelocidade(sentidoDoCarro);
        this.ajustarDirecao(sentidoDoCarro);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2d.velocity = new Vector2 (velocidade, rigidbody2d.velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if (collision.tag.Equals("Barreira"))
        {
            this.gerador.removerCarroDaLista(this);
            destruir();
        }
    }


    public void destruir()
    {
        GameObject.Destroy(this.gameObject);
    }

    public bool sentido()
    {
        Vector3 posicao;

        //retorno = true = indo para >>
        //retorno = false = indo para <<
        bool retorno = false;

        posicao = this.transform.position;
        retorno = posicao.y < 0;

        return retorno;

    }

    public void mudarCor(int cor)
    {
        switch (cor)
        {
            case 1:
                renderisador.material.color = Color.black;
                break;
            case 2:
                renderisador.material.color = Color.blue;
                break;
            case 3:
                renderisador.material.color = Color.cyan;
                break;
            case 4:
                renderisador.material.color = Color.green;
                break;
            case 5:
                renderisador.material.color = Color.white;
                break;
            case 6:
                renderisador.material.color = Color.red;
                break;
            case 7:
                renderisador.material.color = Color.magenta;
                break;
            case 8:
                renderisador.material.color = Color.yellow;
                break;
            case 9:
                renderisador.material.color = new Color(255f / 255, 127f / 255, 0);
                break;
            default:
                renderisador.material.color = new Color(255f / 255, 0, 255f / 255);
                break;
        }
    }

    public void mudarSprite()
    {
        SpriteRenderer spriteAtual;

        spriteAtual = GetComponent<SpriteRenderer>();

        if (this.tipoDeVeiculo <= this.percentualSprite1)
        {
            spriteAtual.sprite = this.spriteCaminhao;
            this.tag = "Caminhao";
        }            
        else if (this.tipoDeVeiculo > this.percentualSprite2)
        {
            spriteAtual.sprite = this.spriteCaminhaoDuplo;
            this.tag = "CaminhaoDuplo";
        }            
        else
        {
            spriteAtual.sprite = this.spriteCarro;
            this.tag = "Carro";
        }
    }

    public void ajustarSentidoVelocidade(bool sentidoDoCarro)
    {
        if (sentidoDoCarro)
            this.velocidade = -this.velocidade;
    }

    public void ajustarModuloVelocidade(float modulo)
    {
        if (this.velocidade < 0)
            this.velocidade = -modulo;
        else
            this.velocidade = modulo;
    }

    public void ajustarDirecao(bool sentidoDoCarro)
    {
        SpriteRenderer spriteAtual;
        Vector3 posicao;

        posicao = this.transform.position;

        if (! sentidoDoCarro)
        {
            spriteAtual = GetComponent<SpriteRenderer>();
            spriteAtual.flipX = true;
        }
            
    }


    public float getX()
    {
        float retorno = 0;

        retorno = this.transform.position.x;

        return retorno;
    }

    public float getY()
    {
        float retorno = 0;

        retorno = this.transform.position.y;

        return retorno;
    }

    public void setPercentualSprite1(float percentualMenor, float percentualMaior)
    {
        this.percentualSprite1 = percentualMenor;
        this.percentualSprite2 = percentualMaior;

        this.mudarSprite();
    }

    public void setGerador(geradorDeCarros geradorDoCarro)
    {
        this.gerador = geradorDoCarro;
    }

}