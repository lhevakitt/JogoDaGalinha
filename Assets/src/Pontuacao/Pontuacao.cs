using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    private int pontuacao;

    private void Awake()
    {
        reiniciarPontuacao();
    }

    public void adicionarPontos()
    {
        this.pontuacao = this.pontuacao + 1;

        //Debug.Log(this.pontuacao);
    }

    public void removerPontos()
    {
        this.pontuacao = this.pontuacao - 1;

        if (this.pontuacao < 0)
            this.pontuacao = 0;

        //Debug.Log(this.pontuacao);
    }

    public void reiniciarPontuacao()
    {
        this.pontuacao = 0;
    }

}
