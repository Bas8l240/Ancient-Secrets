using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;
    bool LeftIsPressed = false;

    public float Force;

    public AudioSource footsteps;

    void Update()
    {
        if (LeftIsPressed)
        {
            player.transform.Translate(0, 0, Force * Time.deltaTime);
            footsteps.enabled = true;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LeftIsPressed = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeftIsPressed = false;
        footsteps.enabled = false;
    }

}
