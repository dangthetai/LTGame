using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
namespace SongokuGame
{
    public class InputState
    {
        KeyboardState lastKeyBoardState;
        KeyboardState currentKeyBoardState;
        bool isActive = false;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public InputState()
        {
            lastKeyBoardState = new KeyboardState();
            currentKeyBoardState = new KeyboardState();
        }

        public void Update(GameTime gameTime)
        {
            lastKeyBoardState = currentKeyBoardState;
            currentKeyBoardState = Keyboard.GetState();          
        }

        public bool isNewKeyPress(Keys key)
        {
            return lastKeyBoardState.IsKeyUp(key) && currentKeyBoardState.IsKeyDown(key);
        }

        public bool isKeyPress(Keys key)
        {
            return currentKeyBoardState.IsKeyDown(key);
        }

        public bool isKeyKeepPress(Keys key)
        {
            return lastKeyBoardState.IsKeyDown(key) && currentKeyBoardState.IsKeyDown(key);
        }

        public bool isMenuSelect()
        {
            return isNewKeyPress(Keys.Enter);
        }

        public bool isMenuUpKeepSelect()
        {
            return isKeyKeepPress(Keys.Up) && isActive;
        }

        public bool isMenuUp()
        {
            return isNewKeyPress(Keys.Up) && isActive;
        }

        public bool isMenuDown()
        {
            return isNewKeyPress(Keys.Down) && isActive;
        }
    }
}
