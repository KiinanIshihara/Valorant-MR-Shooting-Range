using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{

    public SimpleShoot simpleShoot;
    public OVRInput.Button shootButton;
    private OVRGrabbable grabbable;
    public AudioSource audio;
    public AudioClip sound;


    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        audio = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController())) {
            simpleShoot.StartShoot();
            audio.PlayOneShot(sound);
        }
    }
}
