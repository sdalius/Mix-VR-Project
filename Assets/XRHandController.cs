using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public enum HandType
{
    Left,
    Right
}

public class XRHandController : MonoBehaviour
{
    public HandType handType;
    private Animator animator;
    private InputDevice inputDevice;
    public float thumbMoveSpeed;

    private float indexValue;
    private float thumbValue;

    private float threeFingersValue;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inputDevice = GetInputDevice();
        
    }
    void Update() {
        AnimateHand();
        
    }

    InputDevice GetInputDevice()
    {
    InputDeviceCharacteristics controlCharactersic =  InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller;
    if(handType == HandType.Left)
    {
        controlCharactersic = controlCharactersic | InputDeviceCharacteristics.Left;
    }
    else{
        controlCharactersic = controlCharactersic | InputDeviceCharacteristics.Right;

    }
    List<InputDevice> inputDevices = new List<InputDevice>();
    InputDevices.GetDevicesWithCharacteristics(controlCharactersic, inputDevices);
    return inputDevices[0];
    
    }
    void AnimateHand()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger, out indexValue);
        inputDevice.TryGetFeatureValue(CommonUsages.grip, out threeFingersValue);


        inputDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        
        inputDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);
        if(primaryTouched || secondaryTouched)
        {
            thumbValue += thumbMoveSpeed;
        } else{
            thumbValue -= thumbMoveSpeed;
        }
        thumbValue = Mathf.Clamp(thumbValue, 0, 1);

        
        // animator.SetFloat("Index",indexValue);
        // animator.SetFloat("ThreeFingers", threeFingersValue);
        // animator.SetFloat("Thumb", thumbValue);

    }

    
}
