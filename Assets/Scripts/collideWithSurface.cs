using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideWithSurface : MonoBehaviour
{
    public bool inWater = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wSurface"))
        {
            Debug.Log("touch");
            if (inWater == false)
            {
                inWater = true;
                Debug.Log("Underwater");
            } else {
                inWater = false;
                Debug.Log("Above water");
            }
        }
    }
}
