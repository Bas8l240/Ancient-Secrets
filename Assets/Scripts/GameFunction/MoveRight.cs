using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    bool RightIsPressed = false;

    public float Force;

    public AudioSource footsteps;
    public Animator playerAnim;

    void Update()
    {
        if (RightIsPressed)
        {
            player.transform.Translate(0, 0, -Force * Time.deltaTime);
            footsteps.enabled = true;
            playerAnim.SetTrigger("PlayerRunningRight");
        }
     
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        RightIsPressed = true;
 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        RightIsPressed = false;
        footsteps.enabled = false;

        playerAnim.ResetTrigger("PlayerRunningRight");
        playerAnim.SetTrigger("PlayerStopped");
    }

}
