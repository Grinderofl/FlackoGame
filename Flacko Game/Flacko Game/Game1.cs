using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Flacko_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /*private AnimatedSprite _texture;
        private const float Rotation = 0;
        private const float Scale = 0.25f;
        private const float Depth = 0.5f;

        private Viewport _viewport;
        private Vector2 _charPos;
        private const int Frames = 18;
        private const int FramesPerSec = 10;

        private Animations _animations;

        private Directions _currentDirection;*/

        private KeyboardState _previousState;

        private Character _player1;

        private Editor _editor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //_texture = new AnimatedSprite(Vector2.Zero, Rotation, Scale, Depth);
            //_animations = new Animations();
            TargetElapsedTime = TimeSpan.FromSeconds(1/30.0);
            //_currentDirection = Directions.Right;
            _player1 = new Character();
            _previousState = Keyboard.GetState();
            _editor = new Editor(this);
            Components.Add(_editor);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //_texture.Load(Content, "Stand\\zputtframe", FramesPerSec);
            //_animations.Load(Stance.Idle, _texture);
            //_viewport = graphics.GraphicsDevice.Viewport;
            //_charPos = new Vector2(_viewport.Width/3, _viewport.Height/3);
            _player1.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            var state = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (state.IsKeyDown(Keys.Right))
            {
                _player1.Direction = Directions.Right;
                _player1.Moving = true;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                _player1.Direction = Directions.Left;
                _player1.Moving = true;
            }

            if ((_previousState.IsKeyDown(Keys.Right) || _previousState.IsKeyDown(Keys.Left)) && (state.IsKeyUp(Keys.Right) && state.IsKeyUp(Keys.Left)))
            {
                _player1.Moving = false;
                _player1.ResetAnimation();
            }

            _editor.Enabled = true;

            float elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
            _player1.Update(elapsed);
            //_animations.UpdateFrame(Stance.Idle, elapsed);
            
            _previousState = state;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            _player1.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }

    /*public class AnimatedTexture
    {
        private readonly Vector2 _origin;
        private readonly float _rotation;
        private readonly float _scale;
        private readonly float _depth;
        private bool Paused;
        private float _totalElapsed;
        private float _timePerFrame;
        private int _frame;
        private int _framecount;
        private Texture2D _texture;
        
        public AnimatedTexture(Vector2 origin, float rotation, float scale, float depth)
        {
            _origin = origin;
            _rotation = rotation;
            _scale = scale;
            _depth = depth;
            _totalElapsed = 0;
            Paused = false;
        }

        public void UpdateFrame(float elapsed)
        {
            if (Paused)
                return;
            _totalElapsed += elapsed;
            if(_totalElapsed > _timePerFrame)
            {
                _frame++;
                _frame = _frame%_framecount;
                _totalElapsed -= _timePerFrame;
            }
        }

        public void DrawFrame(SpriteBatch batch, Vector2 screenPos)
        {
            DrawFrame(batch, _frame, screenPos);
        }

        private void DrawFrame(SpriteBatch batch, int frame, Vector2 screenPos)
        {
            int fw = _texture.Width/_framecount;
            Rectangle source = new Rectangle(fw * frame, 0, fw, _texture.Height);
            batch.Draw(_texture, screenPos, source, Color.White, _rotation, _origin, _scale, SpriteEffects.None, _depth);
        }

        public void Load(ContentManager content, string charsprite, int frames, int framesPerSec)
        {
            _texture = content.Load<Texture2D>(charsprite);
            _framecount = frames;
            _timePerFrame = 0.6f/framesPerSec;
        }
    }*/
}
