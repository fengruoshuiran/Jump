using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jump
{
    public static class Setting
    {
        public const float Rate = 1.0F;
        public const float MoveTime = Rate * 150.0F;
        public const float FloatVelocity = Rate * 0.75F;

        public const KeyCode jumpKey = KeyCode.Space;

        public static bool isCheat = false;
        public static bool isTest = false;

        public const bool Adirection = true;
        public const bool Bdirection = false;
    }
}
