using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider coll;
    void Start()
    {
        coll = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Player_Health player_Health = player.GetComponent<Player_Health>();
            player_Health.Get_Hit();
        }
    }

    public void Deactivate_Collision(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            coll.enabled = false;
            StartCoroutine(Dash_Speedup(.4f));
        }
    }

    IEnumerator Dash_Speedup(float time)
    {
        yield return new WaitForSeconds(time);
        coll.enabled = true;
    }
}
