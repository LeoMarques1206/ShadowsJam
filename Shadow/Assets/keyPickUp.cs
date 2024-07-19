using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public Transform key;     
    public Transform player;   
    private bool isFollowing;  

    void Start()
    {
        isFollowing = false;
    }

    void Update()
    {
        if (isFollowing)
        {
            FollowPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isFollowing = true;
        }
    }

    private void FollowPlayer()
    {
        key.position = Vector3.Lerp(key.position, player.position, Time.deltaTime * 5f);
    }
}
