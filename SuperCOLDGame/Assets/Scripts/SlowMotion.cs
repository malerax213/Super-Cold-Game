using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using System;

public class SlowMotion : MonoBehaviour
{
    private float slowMo = 0.1f;
    private float normTime = 1.0f;
    private bool doSlowMo = false;

    [SerializeField] private GameObject player;

    void Update()
    {
        Vector3 movementVector = player.GetComponent<MainCharMovement>().v;
        if (movementVector.magnitude > 0)
        {
            if (doSlowMo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                
                doSlowMo = false;
            }
        }
        else
        {   
            if (!doSlowMo)
            {
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                doSlowMo = true;
            }
        }
    }
}
