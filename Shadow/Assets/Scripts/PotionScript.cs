using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PotionScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject vfxPick;
    public GameObject potionShadow;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerMovement.PotEffect = true;
            gameObject.SetActive(false);
            vfxPick.SetActive(true);
            potionShadow.SetActive(false);
        }
    }
}
