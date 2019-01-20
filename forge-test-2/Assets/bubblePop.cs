using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class bubblePop : MonoBehaviour {

    public GameObject bubbleGO;
    private GameObject thisObject;
    private GameObject innerGO;

    private Color bubbleGOcolor;

    private float maxTimeAnim;
    private bool OnHand;
    private Interactable thisInteractable;

	// Use this for initialization
	void Start () {
        thisObject = this.gameObject;
        thisInteractable = thisObject.GetComponent<Interactable>();
        bubbleGO = thisObject.transform.GetChild(0).gameObject;
        maxTimeAnim = 3.0f;
        OnHand = false;
        innerGO = thisObject.transform.GetChild(1).gameObject;

        innerGO.GetComponent<Rigidbody>().detectCollisions = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (OnHand)
        {
            maxTimeAnim -= Time.deltaTime;
            if (maxTimeAnim > 0.0f)
            {
                GrowObject();
                FadeBubble();
            } else
            {
                OnHand = false;
            }

        }

        if (maxTimeAnim <= 0.0f)
        {
            //thisInteractable.highlightOnHover = false;

            //innerGO.GetComponent<Rigidbody>().detectCollisions = true;
            thisObject.GetComponent<Rigidbody>().useGravity = true;
            //bubbleGO.GetComponent<Collider>().enabled = false;

            //innerGO.GetComponent<Rigidbody>().useGravity = true;
            
            
        }
    }

    public void EnableGravity()
    {
        thisObject.GetComponent<Rigidbody>().useGravity = true;
        //bubbleGO.GetComponent<Collider>().enabled = false;
        //innerGO.GetComponent<Rigidbody>().useGravity = true;
        //innerGO.GetComponent<Rigidbody>().detectCollisions = true;
    }


    public void popOnHand()
    {
        OnHand = true;
    }

    public void GrowObject()
    {
        thisObject.transform.localScale = thisObject.transform.localScale * 1.003f;
    }

    public void FadeBubble()
    {
        bubbleGOcolor = bubbleGO.GetComponent<MeshRenderer>().material.color;
        bubbleGOcolor.a -= 0.1f;
        bubbleGO.GetComponent<MeshRenderer>().material.color = bubbleGOcolor;
        //Debug.Log("color alpha");
    }
}
