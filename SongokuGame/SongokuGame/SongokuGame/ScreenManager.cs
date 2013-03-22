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


namespace SongokuGame
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ScreenManager : DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }
        SpriteFont font;

        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        List<GameScreen> screens = new List<GameScreen>();

        InputState input = new InputState();

        internal InputState Input
        {
            get { return input; }
            set { input = value; }
        }

        public ScreenManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            base.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            font = Game.Content.Load<SpriteFont>("Fonts/gameFont");
            foreach (GameScreen screen in screens)
            {
                screen.LoadContent();
            }
        }

        protected override void UnloadContent()
        {
            foreach (GameScreen screen in screens)
            {
                screen.UnloadContent();
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            input.Update(gameTime);
            foreach (GameScreen screen in screens)
            {
                screen.HandleInput(input, gameTime);
                screen.Update(gameTime);
            }
            
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameScreen screen in screens)
            {
                screen.Draw(gameTime);
            }
        }
        public void AddScreen(GameScreen screen)
        {
            screen.ScreenManager = this;
            screens.Add(screen);
        }
    }
}
