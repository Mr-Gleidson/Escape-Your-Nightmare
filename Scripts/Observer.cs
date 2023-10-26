using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    /*Classe para detec��o do personagem*/
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        /*Verificando se o personagem est� no alcance da vis�o*/
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*Verificando se o personagem est� no alcance da vis�o, mas entendendo que n�o � o fim do jogo*/
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
    /*Verifica��o se o campo de vis�o do inimigo est� limpa*/
    void Update()
    {
        /*A verifica��o s� ocorre se o personagem estiver dentro do alcance da vis�o inimiga*/
        if (m_IsPlayerInRange)
        {
            /*Vari�veis para dire��o do personagem*/
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            /*M�todo Raycast retorna um bool que � true quando atinge algo e false quando n�o atinge nada*/
            if (Physics.Raycast(ray, out raycastHit))
            {
                /*Verificando o que foi atingido pelo campo de vis�o*/
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}