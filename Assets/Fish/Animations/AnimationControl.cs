using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationControl : MonoBehaviour{

    public Animator animator;
    public static float varAnimSpeed;
    public float animSpeedMin = 0.15f;
    public float animSpeedMax = 3.25f;

    void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("IsMoving", true);

    }


    void FixedUpdate(){
        FishAnim();

    }

    //fish is now always animated;
    //take velocity from fish as animation-speed, make sure its min is 0.15, max is 3.25 (clamp)
    //fuck yeah elegant solution to hours of trial & error
    private void FishAnim(){
        Rigidbody rb = GetComponent<Rigidbody>();
        varAnimSpeed=Mathf.Clamp(rb.velocity.magnitude, animSpeedMin, animSpeedMax);
        animator.speed=varAnimSpeed;
        // Debug.Log(animator.speed);
    }
}
