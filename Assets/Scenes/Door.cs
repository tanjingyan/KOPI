using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator _doorAnim;
    public AudioSource DoorOpenSound;

    private void OnTriggerEnter(Collider other){
        _doorAnim.SetBool("isOpening", true);
        DoorOpenSound.Play();
    }

    private void OnTriggerExit(Collider other){
        _doorAnim.SetBool("isOpening", false);
        DoorOpenSound.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
        DoorOpenSound = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
