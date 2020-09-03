using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlueGenerointi : MonoBehaviour
{

    //muuttujat 
    public GameObject[] Alueet;
    public Transform AlueSpawnerPos;
    public int AlueMäärä = 0;
    public float NewPos = 5.0f;

    private int randomNum;
    private float odotusAika = 1.2f;
    private GameObject alue;
    
    


    void Start()
    {
        Alue();
    }

    
    void Update()
    {
        
    }

    //tehdään uusi metodi
    public void Alue()
    {
        alue = Instantiate (Alueet [Random.Range(0,5)], AlueSpawnerPos.position, Quaternion.identity) as GameObject;
        Vector3 temp = AlueSpawnerPos.position;
        temp.y = 0;
        temp.x += 5;
        temp.z = 0;
        AlueSpawnerPos.position = temp;
        StartCoroutine(wait ());
    }


    //määritetään odottaminen
    IEnumerator wait ()
    {
        yield return new WaitForSeconds (odotusAika);
        AlueMäärä += 1;
        Alue();
    }
}
