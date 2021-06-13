using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject PlayerHead;

    private Vector3 offset; //Private variable to store offset distance between player and camera.

    void Start()
    {
        //calculate and store offset value: distance between player's position and camera's postion.
        offset = transform.position - PlayerHead.transform.position;
    }

    
    void Update()
    {
        transform.position = PlayerHead.transform.position + offset;
    }
}
