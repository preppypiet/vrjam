using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Joystick : MonoBehaviour
{

    public LinearMapping linearMapping;
    public float Speed = 30.0f;
    Vector3 _previousHandPosition;
    Transform _base;

    public delegate void OnPlayerMove(Vector3 amount);
    public OnPlayerMove OnMove;

    // Use this for initialization
    void Start()
    {
        //Valve.VR.OpenVR.System.ResetSeatedZeroPose();
        if (linearMapping == null)
        {
            linearMapping = GetComponent<LinearMapping>();
        }
        
        _base = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandHoverUpdate(Hand hand)
    {
        if (hand.GetStandardInteractionButtonDown())
        {
            hand.HoverLock(GetComponent<Interactable>());
            _previousHandPosition = hand.transform.position;

            //initialMappingOffset = linearMapping.value - CalculateLinearMapping(hand.transform);
            /*sampleCount = 0;
            mappingChangeRate = 0.0f;*/
        }

        if (hand.GetStandardInteractionButtonUp())
        {
            hand.HoverUnlock(GetComponent<Interactable>());

            //CalculateMappingChangeRate();
        }


        if (hand.GetStandardInteractionButton())
        {
            /// todo: add proper movement here, for now just use touchpad

			/*var currentHandPosition = hand.transform.position;
            if(Vector3.Distance(currentHandPosition, _previousHandPosition) >= 0.005f) {
                var diff = currentHandPosition - _previousHandPosition;
                diff.Normalize();
                _base.rotation = _base.rotation * Quaternion.Euler(diff.z * Speed, 0, -diff.x * Speed);
                _previousHandPosition = currentHandPosition;

                OnMove(diff);
            } */

			
             var device = SteamVR_Controller.Input((int)hand.controller.index);
             //uncomment below for press touchpad
             //if(device.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)) {
                 // touchpad and interact button down
                  var touchpad = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
                  OnMove(new Vector3(touchpad.x, touchpad.y, 0));
             //}
        }
    }
}
