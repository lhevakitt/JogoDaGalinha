using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarFaixaCentral : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ControleCamera controleCamera;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.controleCamera = FindObjectOfType<ControleCamera>();

        this.gerarFaixaCentral();
    }

    private void gerarFaixaCentral()
    {
        Vector2 tamanho = this.controleCamera.getTamanhoDaCamera();
        tamanho.y = 1;

        this.spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        this.spriteRenderer.size = tamanho;
        this.spriteRenderer.color = new Color(1f, 1f, 0);
        this.transform.localScale = new Vector3(2, 2, 1);
    }
}
