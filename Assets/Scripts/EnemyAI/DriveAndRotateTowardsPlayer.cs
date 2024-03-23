using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveAndRotateTowardsPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float maxCloseup = 3f;
    [SerializeField] private float moveSpeed = 1f;

    private void LateUpdate()
    {
        RotateTowards();
        MoveTowards();
    }
    
    private void MoveTowards()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > maxCloseup)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    private void RotateTowards()
    {
        Vector3 playerPos = player.position;
        Vector3 myPos = transform.position;
        
        Vector3 forwardVector = transform.forward;
        Vector3 playerVector = playerPos - myPos;
        
        float vectorMagnitudeToPlayer = Mathf.Sqrt(Mathf.Pow(playerPos.x - myPos.x, 2) + Mathf.Pow(playerPos.z - myPos.z, 2));
        float vectorMagnitudeToForward = Mathf.Sqrt(Mathf.Pow(forwardVector.x, 2) + Mathf.Pow(forwardVector.z, 2));

        float angle = Mathf.Acos((forwardVector.x * playerVector.x + forwardVector.z * playerVector.z) / (vectorMagnitudeToPlayer * vectorMagnitudeToForward));

        var crossProd = new Vector3(forwardVector.y * playerVector.z - forwardVector.z * playerVector.y, 
            forwardVector.x * playerVector.z - forwardVector.z * playerVector.x, 
            forwardVector.x * playerVector.y - forwardVector.y * playerVector.x);

        int clockwise = 1;
        if (crossProd.y > 0) clockwise = -1;
        
        if (!float.IsNaN(angle)) transform.Rotate(0,angle * Mathf.Rad2Deg * clockwise,0);
    }

    public Transform GetPlayer()
    {
        return player;
    }
    
}
