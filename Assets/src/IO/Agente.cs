using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Agente : Agent
{
    [SerializeField] private Transform chegada;

    private Jogador jogador;

    private void Awake()
    {
        this.jogador = this.GetComponent<Jogador>();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.position);
        sensor.AddObservation(this.chegada);
        base.CollectObservations(sensor);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        float moverParaCima = vectorAction[0];
        float moverParaBaixo = vectorAction[1];

        Debug.Log(moverParaCima);

        if (moverParaCima > 0)
            this.jogador.moverParaCima();
        else if (moverParaBaixo > 0)
            this.jogador.moverParaBaixo();

        base.OnActionReceived(vectorAction);
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxisRaw("Horizontal");
        actionsOut[1] = Input.GetAxisRaw("Vertical");
        base.Heuristic(actionsOut);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetReward(1f);
        EndEpisode();
    }
}
