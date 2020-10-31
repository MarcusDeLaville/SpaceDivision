using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClosePanel : MonoBehaviour
{
    // по идее я мог скрипт панели, в котором бы имелись Animator и Image, и брать их оттуда. Но я не уверен. что это правильно. 
    public void OpenPanel(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("isOpen", true);
        gameObject.GetComponent<Image>().raycastTarget = true;
    }

    public void ClosePanel(GameObject gameObject)
    {
        gameObject.GetComponent<Animator>().SetBool("isOpen", false);
        gameObject.GetComponent<Image>().raycastTarget = false;
    }
}
