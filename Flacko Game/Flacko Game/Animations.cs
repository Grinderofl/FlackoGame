using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Flacko_Game
{
    public enum Directions
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    public enum Stance
    {
        Idle,
        IdleLeft,
        JumpStart,
        Landed,
        Falling,
        Moving,
        CrouchStart,
        Crouch,
        CrouchEnd,
        Climbing,
        PullUp,
        Shoot,
        RunningLeft,
        RunningRight
    }

    public class Animations
    {
        private readonly Dictionary<Stance, AnimatedSprite> _animations;
        private Stance _prevStance;

        public Animations()
        {
            _animations = new Dictionary<Stance, AnimatedSprite>();
            
        }

        public void UpdateFrame(Stance stance, float elapsed)
        {
            if (_animations.ContainsKey(stance))
            {
                _animations[stance].UpdateFrame(elapsed);
                _prevStance = stance;
            }
            else
                _animations[_prevStance].UpdateFrame(elapsed);
        }

        public void DrawFrame(Stance stance, SpriteBatch batch, Vector2 screenPos)
        {
            if (_animations.ContainsKey(stance))
            {
                _animations[stance].DrawFrame(batch, screenPos);
                _prevStance = stance;
            }
            else
                _animations[_prevStance].DrawFrame(batch, screenPos);
        }

        public void Load(Stance stance, AnimatedSprite sprite)
        {
            _animations.Add(stance, sprite);
        }

        public void ResetAnimations()
        {
            foreach(var item in _animations)
            {
                item.Value.ResetElapsed();
            }
        }
    }
}
