using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flacko_Game
{
    public class WorldElement
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
    }
}
