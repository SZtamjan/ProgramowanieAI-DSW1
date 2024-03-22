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
        player = GetComponent<DriveTowardsPlayer>().GetPlayer().transform;
    }

    private void Update()
    {
        if(player==null)
            return;
        
        Vector3 dir = player.position - (transform.position); //Vector3.Dot
        Quaternion whereLook = Quaternion.LookRotation(dir); //Trzeba policzyć samemu
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, whereLook, Time.deltaTime*20f);

        float dot = Vector3.Dot(gameObject.transform.position, player.position);
        
        

    }
}
