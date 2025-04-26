using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_HP : MonoBehaviour
{
    // Start is called before the first frame update

    public Boss2_Phase2_HP real_HP;
    [SerializeField] GameObject[] hand_parts;

    public int HP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Get_Hit()
    {
        HP--;
        real_HP.HP--;
        if(HP <= 0)
        {
            foreach(GameObject part in hand_parts)
            {
                part.SetActive(false);
            }
        }
    }
}
