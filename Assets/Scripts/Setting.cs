using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public static class Setting
    {
        public const float Rate = 1.0F;
        public const float FloatVelocity = Rate * 3.0F;
        public const float jumpRate = Rate * 0.1F;
        public const float MaxJumpDistance = Rate * 15F;

        public const float MaxPlayerScaleChangeRate = 0.5F;

        public const int FrameRate = 60;
        public const int AnimationTime = FrameRate / 2;
        public const int MaxJumpTime = (int)(MaxJumpDistance / jumpRate);
        public const int MaxRecoveryTime = AnimationTime / 2;

        public const KeyCode jumpKey = KeyCode.Space;
        public const KeyCode playKey = KeyCode.Space;
        public const KeyCode pauseKey = KeyCode.Escape;

        public const int defaultScoreRate = 1;

        public static bool isCheat = false;
        public static bool isTest = false;

        public const bool Adirection = true;
        public const bool Bdirection = false;
    }
}
