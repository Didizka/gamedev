using System;
using Microsoft.Xna.Framework;

namespace MonoGame
{
     public class AnimationFrame
    {
        // Defines the area of the Texture2D which will be displayed by the AnimationFrame. This value is measured in pixels, with the top left being (0, 0)
        public Rectangle SourceRectangle { get; set; }

        // Defines how long an AnimationFrame is displayed when used in an Animation.
        public TimeSpan Duration { get; set; }

    }
}
