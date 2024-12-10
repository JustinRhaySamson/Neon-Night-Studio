using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_At : MonoBehaviour
{
    // Start is called before the first frame update
    public int damping;
    GameObject player;
    Transform player_transform;
    void Start()
    {
        player = GameObject.Find("Player");
        player_transform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        //transform.LookAt(player_transform.position, Vector3.up);
        var lookPos = player_transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}
