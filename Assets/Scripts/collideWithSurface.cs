using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideWithSurface : MonoBehaviour
{
    public bool inWater = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checking for a collision with the watersurface.
        if (collision.CompareTag("wSurface"))
        {
            GameObject player = GameObject.Find("PlayerBody");
            //checking if character is inside the water or not.
            Debug.Log("touch");
            if (inWater == false)
            {
                inWater = true;
                Debug.Log("Underwater");
                IEnumerator WaitUnderWater()
                {
                    //Print the time of when the function is first called.
                    Debug.Log("Started Coroutine at timestamp : " + Time.time);

                    //yield on a new YieldInstruction that waits for a certain amount of seconds.
                    yield return new WaitForSeconds(0.25f);
                    //movement switch
                    player.GetComponent<PlayerMovWithGrav>().enabled = false;
                    player.GetComponent<PlayerMovNoGrav>().enabled = true;

                    //After we have waited 5 seconds print the time again.
                    Debug.Log("Finished Coroutine at timestamp : " + Time.time);
                }
                StartCoroutine(WaitUnderWater());
            }
            else
            {
                inWater = false;
                Debug.Log("Above water");
                IEnumerator WaitAboveWater()
                {
                    //Print the time of when the function is first called.
                    Debug.Log("Started Coroutine at timestamp : " + Time.time);

                    //extra upward force
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 16f), ForceMode2D.Impulse);
                    //yield on a new YieldInstruction that waits for a certain amount of seconds.
                    yield return new WaitForSeconds(0.25f);
                    //movement switch
                    player.GetComponent<PlayerMovNoGrav>().enabled = false;
                    player.GetComponent<PlayerMovWithGrav>().enabled = true;

                    //After we have waited 5 seconds print the time again.
                    Debug.Log("Finished Coroutine at timestamp : " + Time.time);
                }
                StartCoroutine(WaitAboveWater());
            }
        }
    }
    
    
}
