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
            GameObject player = GameObject.Find("PlayerBody");

            Debug.Log("touch");
            if (inWater == false)
            {
                inWater = true;
                Debug.Log("Underwater");
                player.GetComponent<PlayerMovWithGrav>().enabled = false;
                player.GetComponent<PlayerMovNoGrav>().enabled = true;
            }
            else
            {
                inWater = false;
                Debug.Log("Above water");
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 24f), ForceMode2D.Impulse);
                player.GetComponent<PlayerMovNoGrav>().enabled = false;
                player.GetComponent<PlayerMovWithGrav>().enabled = true;
                
            }
        }
    }
}
