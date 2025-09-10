using UnityEngine;

public class GameConstants
{
    public static class AnimatorParams
    {
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
        public static readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    }
}
