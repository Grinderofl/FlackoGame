using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Flacko_Game
{
    public class AnimatedSprite
    {
        private List<Texture2D> _frames;
        private int _currentFrame;
        private Vector2 _origin;
        private float _rotation;
        private float _scale;
        private float _depth;
        private float _totalElapsed;
        private float _timePerFrame;
        private bool _flipped;

        public void ResetElapsed()
        {
            _totalElapsed = 0;
        }

        public AnimatedSprite(Vector2 origin, float rotation, float scale, float depth, bool flipped = false)
        {
            _origin = origin;
            _rotation = rotation;
            _scale = scale;
            _depth = depth;
            _totalElapsed = 0;
            _frames = new List<Texture2D>();
            _flipped = flipped;
        }

        public void UpdateFrame(float elapsed)
        {
            _totalElapsed += elapsed;
            if(_totalElapsed > _timePerFrame)
            {
                _currentFrame++;
                _currentFrame = _currentFrame%_frames.Count;
                _totalElapsed -= _timePerFrame;
            }
        }

        #region Overloads of DrawFrame

        public void DrawFrame(SpriteBatch batch, Vector2 screenPos)
        {
            DrawFrame(batch, _currentFrame, screenPos, _flipped);
        }

        #endregion

        private void DrawFrame(SpriteBatch batch, int frame, Vector2 screenPos, bool flip = false)
        {
            Rectangle source = new Rectangle(0, 0, _frames[frame].Width, _frames[frame].Height);

            SpriteEffects effect = flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            batch.Draw(_frames[frame], screenPos, source, Color.White, _rotation, _origin, _scale,
                       effect, _depth);
        }

        public void Load(ContentManager manager, string sprite, int framesPerSec)
        {
            _timePerFrame = 1f/framesPerSec;
            string filename;
            for(var i = 1; i < 100; i++)
            {
                filename = sprite + i;
                /*if (File.Exists(manager.RootDirectory + "\\" + filename + ".png"))
                    _frames.Add(manager.Load<Texture2D>(filename));
                else
                    throw new FileLoadException("Not found " + manager.RootDirectory + "\\" + filename);
                    break;*/

                try
                {
                    _frames.Add(manager.Load<Texture2D>(filename));
                }
                catch(ContentLoadException)
                {
                    break;
                }
            }
        }
    }
}
