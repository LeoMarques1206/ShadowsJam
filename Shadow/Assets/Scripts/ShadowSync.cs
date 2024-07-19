using UnityEngine;

public class ShadowSync : MonoBehaviour
{
    [SerializeField] private Transform player; 
    public PlayerMovement playerMovement;

    void Update()
    {
        if(playerMovement.PotEffect == false)
        {
            // Sincroniza a posição X da sombra com a do jogador, mantendo a mesma posição Y da sombra
            Vector3 shadowPosition = transform.position;
            shadowPosition.x = player.position.x;
            transform.position = shadowPosition;
        }   
    }
}
