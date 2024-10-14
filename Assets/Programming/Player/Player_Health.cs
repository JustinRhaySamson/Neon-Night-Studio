using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player_Health : MonoBehaviour
{
    public int HP = 2;
    GameObject UI_Text;
    TMP_Text UI_HP;

    private void Start()
    {
        UI_Text = GameObject.Find("HP number");
        UI_HP = UI_Text.GetComponent<TMP_Text>();
        UI_HP.text = HP.ToString();
    }

    public void Get_Hit()
    {
        HP--;
        UI_HP.text = HP.ToString();
        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
