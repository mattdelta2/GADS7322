using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanAnimation : MonoBehaviour
{

    public WateringCan wateringCan;

    private Animator animator;

    private bool isWatering = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWateringAnimation()
    {

        isWatering = true;

        animator.SetBool("IsWatering", isWatering);
        animator.StartPlayback();
        
    }

    public void onClick()
    {
        PlayWateringAnimation();
        isWatering=false;
        animator.SetBool("IsWatering", isWatering );
    }
}
