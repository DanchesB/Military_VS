using UnityEngine;

public class PlayerView
{
    private Animator animator;
    public PlayerView(Animator animator)
    {
        this.animator = animator;
    }
    public void AnimationMove(Vector2 direction)
    {
        animator.SetFloat("HorisontalMove", direction.x);
        animator.SetFloat("VerticalMove", direction.y);
    }
}
