using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorDeCarros : MonoBehaviour
{
    //Parametros do Jogo (nível de dificuldade)
    [SerializeField] private GameObject prefabCarro;
    [SerializeField] private float tempoParaGerar;
    [SerializeField] private float tempoParaVelocidade;
    [SerializeField] private float velocidadeMaxima;
    [SerializeField] private float velocidadeMinima;
    [SerializeField] private bool habilitarMudancaVelocidade;
    [SerializeField] private float percentualTrocaSpriteMenor;
    [SerializeField] private float percentualTrocaSpriteMaior;

    //Variáveis com valor fixo definido
    private float minimoParaGerar;
    private float minimoParaVelocidade;

    //Variáveis da classe
    private List<Carro> listaDeCarrosGerados;
    private float velocidadePadrao;
    private float cronometroParaGerar;
    private float cronometroVelocidade;

    private void Awake()
    {
        minimoParaGerar = 0.9f;
        minimoParaVelocidade = 3;

        this.listaDeCarrosGerados = new List<Carro>();

        this.velocidadePadrao = Random.Range(velocidadeMinima, velocidadeMaxima);
        this.cronometroParaGerar = Random.Range(minimoParaGerar, tempoParaGerar);
        this.cronometroVelocidade = Random.Range(minimoParaVelocidade, tempoParaVelocidade);
    }

    // Update is called once per frame
    void Update()
    {
        this.cronometroParaGerar = this.cronometroParaGerar - Time.deltaTime;
        this.cronometroVelocidade = this.cronometroVelocidade - Time.deltaTime;

        if (this.cronometroVelocidade <= 0 && habilitarMudancaVelocidade)
            this.alterarVelocidade();

        if (this.cronometroParaGerar <= 0)
            this.gerarCarro();

        //Debug.Log(this.cronometroParaGerar);
    }

    private void alterarVelocidade()
    {
        this.velocidadePadrao = Random.Range(velocidadeMinima, velocidadeMaxima);

        foreach (Carro carro in this.listaDeCarrosGerados)
            carro.ajustarModuloVelocidade(this.velocidadePadrao);

        this.cronometroVelocidade = Random.Range(minimoParaVelocidade, tempoParaVelocidade);
    }

    private void gerarCarro()
    {
        GameObject novoObjeto;
        Carro novoCarro;
        Vector3 posicao;
            
        posicao = this.transform.position;

        novoObjeto = GameObject.Instantiate(this.prefabCarro, posicao, Quaternion.identity);

        novoCarro = novoObjeto.GetComponent<Carro>();
        novoCarro.ajustarModuloVelocidade(this.velocidadePadrao);
        novoCarro.setPercentualSprite1(this.percentualTrocaSpriteMenor, this.percentualTrocaSpriteMaior);
        novoCarro.setGerador(this);

        this.cronometroParaGerar = Random.Range(minimoParaGerar, tempoParaGerar);
        this.listaDeCarrosGerados.Add(novoCarro);

        //Debug.Log(this.listaDeCarrosGerados.Count);
    }

    public void removerCarroDaLista(Carro carroExcluido)
    {
        this.listaDeCarrosGerados.Remove(carroExcluido);
    }

}
