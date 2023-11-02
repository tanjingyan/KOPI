using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoor : MonoBehaviour
{
    private Animator _animator;
    public GameObject txtToDisplay; 
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetBool("open",true);
        }

        
    }
}
