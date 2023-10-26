using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    /*Classe para detecção do personagem*/
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        /*Verificando se o personagem está no alcance da visão*/
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*Verificando se o personagem está no alcance da visão, mas entendendo que não é o fim do jogo*/
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    /*Verificação se o campo de visão do inimigo está limpa*/
    void Update()
    {
        /*A verificação só ocorre se o personagem estiver dentro do alcance da visão inimiga*/
        if (m_IsPlayerInRange)
        {
            /*Variáveis para direção do personagem*/
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            /*Método Raycast retorna um bool que é true quando atinge algo e false quando não atinge nada*/
            if (Physics.Raycast(ray, out raycastHit))
            {
                /*Verificando o que foi atingido pelo campo de visão*/
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}