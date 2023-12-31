﻿using UnityEngine;

namespace Player
{
    public interface IInteraction
    {
        void SetParameters(float distance, LayerMask selectionTheInterior, LayerMask selectionTheKey);
        void InteractionWithObjects();
        void ObjectRotate(float angle);
    }
}