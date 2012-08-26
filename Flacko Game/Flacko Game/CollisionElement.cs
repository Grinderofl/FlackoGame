using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flacko_Game
{
    public enum CollisionType
    {
        Box,
        Triangle
    }

    public class CollisionElement
    {
        public Vector2 Position;

        public CollisionType Type;

        public Rectangle BoxCoords;
        public VertexPositionColor[] TriangleCoords { get; set; }

        private readonly Texture2D _texture;

        public CollisionElement(GraphicsDevice device)
        {
            _texture = new Texture2D(device, 1, 1);
            _texture.SetData(new Color[]{ Color.White });
            BoxCoords = new Rectangle();
            TriangleCoords = new VertexPositionColor[3];
        }

        public void Draw(SpriteBatch batch)
        {
            //if(Type == CollisionType.Box)
                batch.Draw(_texture, Position, BoxCoords, Color.White);
        }
    }
}
