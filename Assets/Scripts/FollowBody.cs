using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBody : MonoBehaviour
{
    GameObject playerBody = GameObject.Find("PlayerBody");
    Transform playerTransform = playerBody.transform;

    Vector2 position = playerTransform.position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
