using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDelete : MonoBehaviour
{
    private float odotusAika = 3.0f;
    public GameObject UI;


    //metodin suorittaminen ja pisteen lisääminen
    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(delete());
        UI = GameObject.FindGameObjectWithTag("UI");
        UI.GetComponent<UIController>().PisteetPlus(1);

    }


    //metodi
    IEnumerator delete()
    {
        yield return new WaitForSeconds(odotusAika);
        Destroy(gameObject);
    }
}
