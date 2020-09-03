using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject Player;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        transform.position = new Vector3 (Player.transform.position.x + 2, 0, 0);
    }
}
