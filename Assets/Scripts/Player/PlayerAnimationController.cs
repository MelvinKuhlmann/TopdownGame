using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Singleton
    public static PlayerAnimationController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerAnimationController found");
            return;
        }

        instance = this;
    }
    #endregion

    public Animator animator;

    public void ChangeAnimation(string animationFlag, bool resetAll = true)
    {
        if (resetAll)
        {
            ResetAnimationParameters();
        }
        animator.SetBool(animationFlag, true);
    }

    public void SlashEnd()
    {
        ChangeAnimation("isIdle");
    }

    public void HandleMovementAnimations(float horizontal, float vertical)
    {
        if (horizontal == 0 && vertical == 0 && animator.GetBool("isSlashing") == false)
        {
            ChangeAnimation("isIdle");
        }
        else
        {
            if (horizontal != 0 && animator.GetBool("isSlashing") == false)
            {
                if (horizontal < 0)
                {
                    ChangeAnimation("isMovingLeft");
                }
                else
                {
                    ChangeAnimation("isMovingRight");
                }
            }
            if (vertical != 0 && animator.GetBool("isSlashing") == false)
            {
                if (vertical < 0)
                {
                    ChangeAnimation("isMovingDown");
                }
                else
                {
                    ChangeAnimation("isMovingUp");
                }
            }
        }
    }

    private void ResetAnimationParameters()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }
}
