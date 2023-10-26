using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    //Rastreando  qual é o próximo waypoint quando alcançar o seu destino atual
    int m_CurrentWaypointIndex;

    void Start()
    {
        //Destino inicial do NavMesh (Inimigo),NavMeshAgent recebe Vector3 como parâmetro
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        //Rastreando se o NavMeshAgent chegou ao seu ponto final atráves da verificação da distância restante até o destino final é menor que a distância de parada definida na janela do inspetor
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //Adicione um ao índice atual, mas se esse incremento colocar o índice igual ao número de elementos na matriz de waypoints, em vez disso, defina-o como zero
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            //Utilizando qualquer ponto de passagem que o inimigo passar como índice
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}