using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace SongokuGame
{
    public class MainMenuScreen: MenuScreen
    {
        Texture2D backgroundTexture;
        ContentManager content;
        Texture2D upMenuTexture;
        Texture2D downMenuTexture;
        Sprite spriteGoku;
        Sprite spriteGohan;

        public MainMenuScreen()
            : base(new Vector2(0, 340))
        {
            MenuEntry pressEnterMenuEntry = new MenuEntry("Press Enter");
            MenuEntry vsMenuEntry = new MenuEntry("VS"); 
            MenuEntry optionMenuEntry = new MenuEntry("Option");

            pressEnterMenuEntry.Selected += pressEnterMenuEntrySelected;
            MenuEntries.Add(pressEnterMenuEntry);
            MenuEntries.Add(vsMenuEntry);
            MenuEntries.Add(optionMenuEntry);
        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");
            Texture2D textureGoku = content.Load<Texture2D>("Textures/goku009");
            Texture2D textureGohan = content.Load<Texture2D>("Textures/gohankameha");
            spriteGoku = new Sprite(textureGoku, 61.4f, 72f, 8);
            spriteGohan = new Sprite(textureGohan, 64, 72, 8);
            backgroundTexture = content.Load<Texture2D>("Textures/background");
            upMenuTexture = content.Load<Texture2D>("Textures/upMenu");
            downMenuTexture = content.Load<Texture2D>("Textures/downMenu");
            MenuSelected1 = content.Load<SoundEffect>("Sounds/menuSelect01");
            MenuSelected2 = content.Load<SoundEffect>("Sounds/menuSelect02");
        }

        public override void UnloadContent()
        {
            content.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            spriteGoku.Update(gameTime);
            spriteGohan.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;
            Viewport viewPort = ScreenManager.GraphicsDevice.Viewport;
            Rectangle fullScreen = new Rectangle(viewPort.X, viewPort.Y, viewPort.Width, viewPort.Height);
            

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, fullScreen, Color.White);
            base.Draw(gameTime);
            spriteGoku.Draw(gameTime, spriteBatch, new Vector2((float)viewPort.Width/2 - 200, (float)viewPort.Height/2), SpriteEffects.None);
            spriteGohan.Draw(gameTime, spriteBatch, new Vector2((float)viewPort.Width / 2 + 200 - spriteGohan.Width, (float)viewPort.Height / 2), SpriteEffects.FlipHorizontally);
            if (ScreenManager.Input.IsActive)
            {
                spriteBatch.Draw(upMenuTexture, new Vector2((viewPort.Width - upMenuTexture.Bounds.Width) / 2, OffSet.Y + font.MeasureString("A").Y/2 - 20 - upMenuTexture.Bounds.Height), Color.White);
                spriteBatch.Draw(downMenuTexture, new Vector2((viewPort.Width - downMenuTexture.Bounds.Width) / 2, OffSet.Y + font.MeasureString("A").Y / 2 + 20), Color.White);
            }
            spriteBatch.End();
            
        }

        protected void pressEnterMenuEntrySelected(object sender, EventArgs e)
        {
            MenuEntries.RemoveAt(EntrySelected);
        }
    }
}
