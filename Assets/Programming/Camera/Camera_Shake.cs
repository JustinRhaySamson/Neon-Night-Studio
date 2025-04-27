using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 0.3f;
    Transform realStartPos;
    public Transform camera2;
    float camera_distance;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        realStartPos = camera2;
    }
    void Update()
    {
        if (start)
        {
            StartCoroutine(Shaking());
            start = false;
        }
        /*if (!start)
        {
            transform.localPosition = new Vector3(0, 0, -14.24f);
        }*/
    }

    public void ShakeIt()
    {
        start = true;
    }

    IEnumerator Shaking()
    {
        Vector3 startPos = transform.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.localPosition = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.localPosition = startPos;
    }

    public void Change_Distance()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Move", true);
    }

    public void Return_Distance()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetBool("Move",false);
    }
}
