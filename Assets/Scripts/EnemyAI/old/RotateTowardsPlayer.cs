using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    private Transform player;
    //[SerializeField] private Transform rotatablePart;
    private void Start()
    {
        player = GetComponent<DriveAndRotateTowardsPlayer>().GetPlayer().transform;
    }

    private void Update()
    {
        if(player==null)
            return;
        
        // Vector3 dir = player.position - (transform.position); //Vector3.Dot
        // Quaternion whereLook = Quaternion.LookRotation(dir); //Trzeba policzyć samemu
        // gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, whereLook, Time.deltaTime*20f);
        
        
        
        Vector3 playerPos = player.position;
        Vector3 dir = playerPos - transform.position;

        var v = dir + Vector3.up * -Vector3.Dot(Vector3.up, dir);
        var q = Quaternion.FromToRotation(Vector3.forward, v);
        
        transform.rotation = Quaternion.FromToRotation(v, dir) * q;
    }
}
