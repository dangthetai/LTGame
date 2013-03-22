using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SongokuGame
{
    public abstract class GameScreen
    {
        ScreenManager screenManager;

        public ScreenManager ScreenManager
        {
            get { return screenManager; }
            set { screenManager = value; }
        }

        public virtual void HandleInput(InputState input, GameTime gameTime) { }
        public virtual void LoadContent() { }
        public virtual void UnloadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
    }
}
