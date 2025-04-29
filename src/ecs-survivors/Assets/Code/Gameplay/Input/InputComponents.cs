using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
    public class InputComponents
    {
        [Input] public class Input : IComponent {  }
        [Input] public class AxisInput : IComponent { public Vector2 Value; }
    }
}