﻿using UnityEngine;
using UnityEngine.UI;

namespace GameUISystem
{
    public interface IUIView
    {
        void HintEnable();
        void HintDisable();
        void KeyCount(string count, string maxCount);
        void RedFlashing();
        void ChangePlayerSizeIcon(Sprite sprite);
    }
}