using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Flacko_Game
{
    public class Character
    {
        public float Speed { get; set; }
        public string Name { get; set; }

        private Rectangle _boundingBox;
        private Vector2 _origin;
        private Vector2 _position;
        private Vector2 _jumpHeight;
        private Stance _stance;

        /// <summary>
        /// Game updates the direction character is moving
        /// </summary>
        public Directions Direction { get; set; }

        public bool Moving { get; set; }

        /// <summary>
        /// Animations for character
        /// </summary>
        private Animations _animations;


        public Character()
        {
            _boundingBox = new Rectangle(0, 0, 30, 30);
            _origin = Vector2.Zero;
            _position = new Vector2(50, 50);
            Speed = 6.0f;
            _jumpHeight = Vector2.Zero;
            Direction = Directions.Right;
            _animations = new Animations();
            Moving = false;
        }

        public void LoadContent(ContentManager content)
        {
            AnimatedSprite idleLeft = new AnimatedSprite(Vector2.Zero, 0.0f, 0.25f, 0.5f, true);
            idleLeft.Load(content, "IdleLeft\\frame", 10);
            _animations.Load(Stance.IdleLeft, idleLeft);
            
            AnimatedSprite idleRight = new AnimatedSprite(Vector2.Zero, 0.0f, 0.25f, 0.5f);
            idleRight.Load(content, "IdleRight\\zputtframe", 10);
            _animations.Load(Stance.Idle, idleRight);

            AnimatedSprite runningLeft = new AnimatedSprite(Vector2.Zero, 0.0f, 0.25f, 0.5f, true);
            AnimatedSprite runningRight = new AnimatedSprite(Vector2.Zero, 0.0f, 0.25f, 0.5f);

            runningLeft.Load(content, "Running\\frame", 12);
            runningRight.Load(content, "Running\\frame", 12);
            _animations.Load(Stance.RunningLeft, runningLeft);
            _animations.Load(Stance.RunningRight, runningRight);
        }

        public void Update(float elapsed)
        {
            var direction = Vector2.Zero;

            if (Direction == Directions.Left)
            {
                _stance = Stance.IdleLeft;
                if (Moving)
                {
                    direction.X = -Speed;
                    if (_jumpHeight == Vector2.Zero)
                        _stance = Stance.RunningLeft;
                }
            }
            else if (Direction == Directions.Right)
            {
                _stance = Stance.Idle;
                if (Moving)
                {
                    direction.X = Speed;
                    if (_jumpHeight == Vector2.Zero)
                        _stance = Stance.RunningRight;
                }
                    
            }

            _position += direction;

            _animations.UpdateFrame(_stance, elapsed);
        }
        
        
        public void Draw(SpriteBatch batch)
        {
            _animations.DrawFrame(_stance, batch, _position);
        }

        public void ResetAnimation()
        {
            _animations.ResetAnimations();
        }
    }
}
