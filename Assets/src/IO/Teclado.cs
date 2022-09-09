using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teclado : MonoBehaviour
{
    [SerializeField] private KeyCode teclaSubir;
    [SerializeField] private KeyCode teclaDescer;
    [SerializeField] private UnityEvent aoPressionarTeclaSubir;
    [SerializeField] private UnityEvent aoPressionarTeclaDescer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(this.teclaSubir))
            this.aoPressionarTeclaSubir.Invoke();
        else if (Input.GetKey(this.teclaDescer))
            this.aoPressionarTeclaDescer.Invoke();
    }
}
