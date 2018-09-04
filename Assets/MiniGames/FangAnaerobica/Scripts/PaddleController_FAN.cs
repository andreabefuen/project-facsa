using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController_FAN : MonoBehaviour {

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float flipperStrength = 10f;
    public float flipperDamper = 1f;
    public string inputButtonName = "LeftPaddle";
    AudioSource Sound;

    private void Awake()
    {
        Sound = GetComponent<AudioSource>();
        GetComponent<HingeJoint>().useSpring = true;
    }

	void Update () {

        JointSpring spring  = new JointSpring();

        spring.spring = flipperStrength;
        spring.damper = flipperDamper;

        if (Input.GetButton(inputButtonName))
        {
            spring.targetPosition = pressedPosition;
        }
        else
        {
            spring.targetPosition = restPosition;
            Sound.pitch = (Random.Range(0.8f, 1.2f));
            Sound.Play();
        }
        GetComponent<HingeJoint>().spring = spring;
        GetComponent<HingeJoint>().useLimits = true;
        JointLimits limits = GetComponent<HingeJoint>().limits;
        limits.min = restPosition;
        limits.max = pressedPosition;
        GetComponent<HingeJoint>().limits = limits;
    }
}
