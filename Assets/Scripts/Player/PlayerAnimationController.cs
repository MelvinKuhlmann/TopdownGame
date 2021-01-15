using UnityEngine;

public class PlayerAnimationController : AnimationController
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
}
