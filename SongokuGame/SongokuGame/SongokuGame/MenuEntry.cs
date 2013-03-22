using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SongokuGame
{
    public class MenuEntry
    {
        string text;
        Vector2 position;

        public MenuEntry(string _text)
        {
            this.text = _text;
        }

        public event EventHandler<EventArgs> Selected;

        protected internal virtual void OnSelectEntry()
        {
            if (Selected != null)
                Selected(this, new EventArgs());
        }

        public void Update(MenuScreen screen, GameTime gameTime)
        {
            float eslapse = (float)gameTime.TotalGameTime.TotalSeconds;
            Viewport viewPort = screen.ScreenManager.GraphicsDevice.Viewport;
            SpriteFont font = screen.ScreenManager.Font;
            Vector2 textSize = font.MeasureString(text);
            Vector2 textPos = new Vector2 ((viewPort.Width - textSize.X)/2, screen.OffSet.Y);
            float x = textPos.X * (float)Math.Pow((double)Math.E, (double)-Global.gamma * eslapse) * (float)Math.Sin(2 * Math.PI * eslapse - Math.PI / 2);
            position = new Vector2(textPos.X + x, textPos.Y);
        }

        public void Draw(MenuScreen screen, GameTime gameTime)
        {
            Viewport viewPort = screen.ScreenManager.GraphicsDevice.Viewport;
            ScreenManager screenManager = screen.ScreenManager;
            SpriteBatch spriteBatch = screenManager.SpriteBatch;
            SpriteFont font = screenManager.Font;
       

            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
