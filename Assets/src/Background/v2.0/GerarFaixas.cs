using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarFaixas : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ControleCamera controleCamera;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.controleCamera = FindObjectOfType<ControleCamera>();

        this.gerarFaixas();
    }

    private void gerarFaixas()
    {
        this.spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        this.spriteRenderer.size = this.controleCamera.getTamanhoDaCamera();
        this.spriteRenderer.color = new Color(1f, 1f, 1f);
        this.transform.localScale = new Vector3(2, 2, 1);
    }
}
