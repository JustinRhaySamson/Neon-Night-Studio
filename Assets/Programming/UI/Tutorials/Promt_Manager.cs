using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Promt_Manager : MonoBehaviour
{
    public TMP_Text[] promt;
    string promt_text;
    Animator animator;
    int amount = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change_Text(string text)
    {
        promt_text = text;
    }

    public void Create_Promt(int i)
    {
        promt[i].text = promt_text;
        animator.SetBool("Appear", true);
    }

    public void Cross_Promt(int i)
    {
        promt[i].text = "<s>" + promt[i].text + "</s>";
        amount++;
        if (amount == 3)
        {
            animator.SetBool("Appear", false);
        }
    }
}
