using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour {

    public AudioClip myAudioClip;
    //public MeshRenderer thisMeshRen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayClip()
    {
        AudioSource.PlayClipAtPoint(myAudioClip, transform.position);
        //thisMeshRen.material.color = new Color white;
    }
}
