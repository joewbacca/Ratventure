using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    //defining camera postion to players position
   private void Update()
    {
        transform.position = new Vector3(player.position.x, 3, transform.position.z);
    }
}
