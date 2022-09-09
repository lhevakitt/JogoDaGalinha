using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour
{
    private Vector2 tamanhoDaCamera;
    private Vector2 escala;

    private void Awake()
    {
        this.escala = this.transform.localScale;
        this.calcularTamanhoDaCamera();
    }

    private void Update()
    {
        //this.imprimirCoordenadas();
    }

    //Calcula as dimensões da camera, baseado na configuração da camera no unity e no aspect ratio da tela onde ela será exibida
    private void calcularTamanhoDaCamera()
    {
        float alturaDaCamera = Camera.main.orthographicSize * 2;
        this.tamanhoDaCamera = new Vector2(Camera.main.aspect * alturaDaCamera, alturaDaCamera);

        //Debug.Log(this.tamanhoDaCamera);
    }

    

    public Vector2 getTamanhoDaCamera()
    {
        return this.tamanhoDaCamera;
    }

    //Métodos para debug
    private void imprimirCoordenadas()
    {
        Vector3 posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(posicaoDoMouse);
    }
}
