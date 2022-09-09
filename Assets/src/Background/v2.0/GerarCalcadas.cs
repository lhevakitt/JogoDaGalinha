using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarCalcadas : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ControleCamera controleCamera;
    private Vector2 tamanhoDaCamera;

    // Start is called before the first frame update
    void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.controleCamera = FindObjectOfType<ControleCamera>();

        this.tamanhoDaCamera = this.controleCamera.getTamanhoDaCamera();

        gerarCalcadaInferior();
        gerarCalcadaSuperior();
    }

    private void gerarCalcadaInferior()
    {
        Color cor = new Color(0.2f, 0.2f, 0.2f);
        Vector2 posicao = new Vector2(0, -tamanhoDaCamera.y / 2);
        Vector2 tamanho = new Vector2(tamanhoDaCamera.x, 1f);

        this.desenharRetangulo(cor, posicao, tamanho);
    }
    private void gerarCalcadaSuperior()
    {
        Color cor = new Color(0.2f, 0.2f, 0.2f);
        Vector2 posicao = new Vector2(0, tamanhoDaCamera.y / 2);
        Vector2 tamanho = new Vector2(tamanhoDaCamera.x, 1f);

        this.desenharRetangulo(cor, posicao, tamanho);
    }

    private void desenharRetangulo(Color cor, Vector2 posicao, Vector2 tamanho)
    {
        this.spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        this.spriteRenderer.color = cor;
        this.spriteRenderer.size = tamanho;
        this.transform.position = posicao;

        Debug.Log(tamanho);
        Debug.Log(posicao);
    }
}
