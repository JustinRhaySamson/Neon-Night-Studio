using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Wall_Script : MonoBehaviour
{
    public string teleporter_name;
    Teleporter_Script teleporter_script;
    // Start is called before the first frame update
    void Start()
    {
        teleporter_script = GameObject.Find(teleporter_name).GetComponent<Teleporter_Script>();
        teleporter_script.ice_wall = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
