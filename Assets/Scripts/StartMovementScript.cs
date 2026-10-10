using UnityEngine;

public class StartMovementScript : MonoBehaviour
{
    public Animator animator;

    public bool ButtonPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ButtonPressed == true)
        {
            bool Pressed = true;
            animator.SetBool("StartMove", Pressed);
        }
        else if (ButtonPressed == false)
        {
            bool Pressed = false;
            animator.SetBool("StartMove", Pressed);
        }
    }
}
