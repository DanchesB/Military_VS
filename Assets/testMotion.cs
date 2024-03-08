using UnityEngine;

public class testMotion : MonoBehaviour
{
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.GetParameter(0);
        animator.SetFloat("HorisontalMove", Input.GetAxis("Horizontal"));
        animator.SetFloat("VerticalMove", Input.GetAxis("Vertical"));
    }
}
