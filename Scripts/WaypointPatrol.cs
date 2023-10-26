using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    //Rastreando  qual � o pr�ximo waypoint quando alcan�ar o seu destino atual
    int m_CurrentWaypointIndex;

    void Start()
    {
        //Destino inicial do NavMesh (Inimigo),NavMeshAgent recebe Vector3 como par�metro
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        //Rastreando se o NavMeshAgent chegou ao seu ponto final atr�ves da verifica��o da dist�ncia restante at� o destino final � menor que a dist�ncia de parada definida na janela do inspetor
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //Adicione um ao �ndice atual, mas se esse incremento colocar o �ndice igual ao n�mero de elementos na matriz de waypoints, em vez disso, defina-o como zero
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            //Utilizando qualquer ponto de passagem que o inimigo passar como �ndice
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}