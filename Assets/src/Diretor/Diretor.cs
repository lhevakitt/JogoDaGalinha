using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    [SerializeField] private Pontuacao pontuacaoPrefab;
    [SerializeField] private GameObject geradorPrefab;
    [SerializeField] private GameObject jogador1;
    [SerializeField] private GameObject jogador2;
    [SerializeField] private GameObject jogador3;
    [SerializeField] private GameObject jogadorIA1;
    [SerializeField] private int punicaoBase;
    [SerializeField] private int maximoDeAtropelamentos;

    private Pontuacao pontuacaoTimeJogador;
    private Pontuacao pontuacaoTimeIA;
    private GameObject[] geradores;
    private string tagTimeJogador;
    private string tagTimeIA;
    private string tagCarro;
    private string tagCaminhao;
    private string tagCaminhaoDuplo;
    private string tagChegada;
    private int faixas;


    private void Awake()
    {
        this.pontuacaoTimeJogador = GameObject.Instantiate<Pontuacao>(pontuacaoPrefab, Vector3.zero, Quaternion.identity);
        this.pontuacaoTimeIA = GameObject.Instantiate<Pontuacao>(pontuacaoPrefab, Vector3.zero, Quaternion.identity);

        this.tagTimeIA = "IA";
        this.tagTimeJogador = "Jogador";
        this.tagCarro = "Carro";
        this.tagCaminhao = "Caminhao";
        this.tagCaminhaoDuplo = "CaminhaoDuplo";
        this.faixas = 0;

        this.criarGeradores(this.faixas);

        jogador1.SetActive(true);
        jogador2.SetActive(false);
        jogador3.SetActive(false);
    }


    private void criarGeradores(int totalDeGeradores)
    {
        GameObject gerador;
        Vector3 posicao;
        int numero = 0;

        this.geradores = new GameObject[totalDeGeradores];

        for (numero = 0; numero < totalDeGeradores / 2; numero = numero + 1)
        {
            posicao = new Vector3(-14f, 0.5f + (numero * 0.8f), 0);
            gerador = GameObject.Instantiate(this.geradorPrefab, posicao, Quaternion.identity);
            gerador.SetActive(true);
            this.geradores[numero] = gerador;
        }

        for (numero = 0; numero < totalDeGeradores / 2; numero = numero + 1)
        {
            posicao = new Vector3(14f, -0.30f - (numero * 0.8f), 0);
            gerador = GameObject.Instantiate(this.geradorPrefab, posicao, Quaternion.identity);
            gerador.SetActive(true);
            this.geradores[(totalDeGeradores / 2) + numero] = gerador;
        }
    }


    public void jogadorAtropelado(GameObject objetoJogador, string tagDoVeiculo)
    {
        Jogador jogador = objetoJogador.GetComponent<Jogador>();

        int atropelamentos = jogador.getNumeroDeAtropelamentos();

        if (atropelamentos >= this.maximoDeAtropelamentos)
            this.punirTime(objetoJogador);
        else
        {
            if (tagDoVeiculo.Equals(this.tagCarro))
                jogador.punirJogador(this.punicaoBase);
            else if (tagDoVeiculo.Equals(this.tagCaminhao))
                jogador.punirJogador(2 * this.punicaoBase);
            else if (tagDoVeiculo.Equals(this.tagCaminhaoDuplo))
                jogador.punirJogador(4 * this.punicaoBase);
        }
    }

    public void premiarTime(GameObject objetoJogador)
    {
        Jogador jogador = objetoJogador.GetComponent<Jogador>();

        jogador.voltarParaPosicaoInicial();

        if (jogador.tag.Equals(tagTimeJogador))
            this.pontuacaoTimeJogador.adicionarPontos();
        else
            this.pontuacaoTimeIA.adicionarPontos();
    }
 
    public void punirTime(GameObject objetoJogador)
    {
        Jogador jogador = objetoJogador.GetComponent<Jogador>();

        jogador.voltarParaPosicaoInicial();

        if (jogador.tag.Equals(tagTimeJogador))
            this.pontuacaoTimeJogador.removerPontos();
        else
            this.pontuacaoTimeIA.removerPontos();
    }

}
