using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ControleCamera controleCamera;
    private Vector2 tamanhoDaCamera;

    private void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.controleCamera = FindObjectOfType<ControleCamera>();
        this.tamanhoDaCamera = this.controleCamera.getTamanhoDaCamera();

        this.ajustarEscala();
    }


    //Ajusta a escala da da tela em função do tamanho do sprite do background e do tamanho da câmera
    //Efeito prático: Preenche todo o background visível pela câmera com a imagem do sprite, independente do aspect ratio.
    private void ajustarEscala()
    {
        Vector3 escala = new Vector3(1, 0.93f, 1);
        Vector3 tamanhoDoSprite = this.spriteRenderer.sprite.bounds.size;

        if (this.tamanhoDaCamera.x >= this.tamanhoDaCamera.y)
        {
            escala.x = escala.x * this.tamanhoDaCamera.x / tamanhoDoSprite.x;    //Paisagem
        }
        else
        {
            escala.y = escala.y * this.tamanhoDaCamera.y / tamanhoDoSprite.y;    //Retrato
        }

        this.transform.position = Vector2.zero;
        this.transform.localScale = escala;

        //Debug.Log(this.tamanhoDaCamera);
        //Debug.Log(tamanhoDoSprite);
        //Debug.Log(escala);
    }
}
