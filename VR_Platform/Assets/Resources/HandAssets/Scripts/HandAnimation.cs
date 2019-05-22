using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class HandAnimation : MonoBehaviour {

    private Animator _anim;
    //private HandGrabbing _handGrab;
    Controller controller;


	// Use this for initialization
	void Start ()
    {
        _anim = GetComponentInChildren<Animator>();
        controller = GetComponent<Controller> ();
        //_handGrab = GetComponent<HandGrabbing>();
	}

	// Update is called once per frame
	void Update ()
    {
		//if we are pressing grab, set animator bool IsGrabbing to true
        if(controller.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            if (!_anim.GetBool("IsGrabbing"))
            {
                _anim.SetBool("IsGrabbing", true);
            }
        }
        else
        {
            //if we let go of grab, set IsGrabbing to false
            if(_anim.GetBool("IsGrabbing"))
            {
                _anim.SetBool("IsGrabbing", false);
            }
        }

	}
}
