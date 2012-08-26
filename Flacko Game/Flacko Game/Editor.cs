using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flacko_Game
{
    public class Editor : DrawableGameComponent
    {
        private Game _game;

        private Dictionary<string, WorldElement> _tiles;

        private Dictionary<string, CollisionElement> _blocks;

        private SpriteBatch _spriteBatch;

        public Editor(Game game) : base(game)
        {
        }

        public override void Initialize()
        {
            DrawOrder = 1000;
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _blocks = new Dictionary<string, CollisionElement>();
            _tiles = new Dictionary<string, WorldElement>();
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            foreach(var item in _blocks)
            {
                item.Value.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            var element = new CollisionElement(Game.GraphicsDevice)
                              {
                                  BoxCoords = new Rectangle(0, 0, 200, 100),
                                  Position = new Vector2(100, 100),
                                  Type = CollisionType.Box
                              };
            _blocks.Add("test", element);

            base.LoadContent();
        }
    }
}
