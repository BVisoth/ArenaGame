using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    Movement moveScript;

    public float dashSpeed;
    public float dashTime;
    public float dashCD;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        dashCD -= Time.deltaTime;

        if(Input.GetKeyDown("e"))
        {
            if(dashCD <= 0)
            {
                StartCoroutine(Dashed());
            }
        }
    }

    IEnumerator Dashed()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.Translate(Vector3.forward * dashSpeed);
            dashCD = 0.3f;

            yield return null;
        }
    }
}
