using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveTowardsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 1f;

    private void Update()
    {
        MoveTowards();
    }

    private void MoveTowards()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    public GameObject GetPlayer()
    {
        return player;
    }
    
}
