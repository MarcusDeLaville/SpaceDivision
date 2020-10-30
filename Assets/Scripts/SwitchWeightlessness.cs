using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeightlessness : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMovenment player))
        {
            player.SetWeightlessnessStatus(false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovenment player))
        {
            player.SetWeightlessnessStatus(true);
        }
    }
}
