using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SongokuGame
{
    public class Sprite
    {
        Texture2D texture;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        int curFrame = 0;
        float width;

        public float Width
        {
            get { return width; }
            set { width = value; }
        }
        float height;

        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        int frames;

        float frameTime = 99;
        int framePerSecond;

        public Sprite(Texture2D _texture, float _width, float _height, int _framePerSecond)
        {
            this.texture = _texture;
            this.width = _width;
            this.height = _height;
            this.framePerSecond = _framePerSecond;
            frames = (int)(texture.Bounds.Width / width);
        }

        public void Update(GameTime gameTime)
        {
            float eslapse = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (frameTime > (1.0f) / framePerSecond)
            {
                frameTime = 0;
                curFrame++;
                if (curFrame >= frames)
                    curFrame = 0;
            }
            else
                frameTime += eslapse;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 pos, SpriteEffects spriteEffect)
        {
            if (curFrame != frames - 1)
                spriteBatch.Draw(texture, pos, new Rectangle((int)(curFrame * width), 0, (int)width, (int)height), Color.White, 0, Vector2.Zero,1.5f ,spriteEffect, 0);   
            else
                spriteBatch.Draw(texture, pos, new Rectangle((int)(curFrame * width), 0, (int)(texture.Bounds.Width - curFrame * width), (int)height), Color.White, 0, Vector2.Zero, 1.5f, spriteEffect, 0);   
        }
    }
}
