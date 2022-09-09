using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarAsfalto : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ControleCamera controleCamera;
    
    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.controleCamera = FindObjectOfType<ControleCamera>();

        this.gerarAsfalto();
    }

    private void gerarAsfalto()
    {
        this.spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
        this.spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        
        this.spriteRenderer.size = this.controleCamera.getTamanhoDaCamera();
    }
}


