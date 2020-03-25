using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationControl : MonoBehaviour{

    public Animator animator;
    void Start(){
        animator = GetComponent<Animator>();
    }
     //TODO: Implement float instead of crude bool 
     //so it doesn't look like the fish is having a fucking stroke
    public void AnimateFishForward(){
        animator.SetBool("IsMoving", true);
    }
    
    public void AnimateFishIdle(){
        animator.SetBool("IsMoving", false);
    }

    void FixedUpdate(){
        // var gamepad = Gamepad.current;
        // if (gamepad == null)
        //     return; //not connected

        //  if (gamepad.aButton.wasPressedThisFrame){
        //      Debug.Log("yeeeeeeeeeeeeeeeeeeeeeah boi");
        //  }
    }
}
