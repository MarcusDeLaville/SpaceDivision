using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenClosePanel : MonoBehaviour
{
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
