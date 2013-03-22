using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace SongokuGame
{
    public class MenuScreen: GameScreen
    {
        List<MenuEntry> menuEntries = new List<MenuEntry>();

        public List<MenuEntry> MenuEntries
        {
            get { return menuEntries; }
            set { menuEntries = value; }
        }
        Vector2 offSet;

        public Vector2 OffSet
        {
            get { return offSet; }
            set { offSet = value; }
        }

        int entrySelected = 0;

        SoundEffect menuSelected1;

        public SoundEffect MenuSelected1
        {
            get { return menuSelected1; }
            set { menuSelected1 = value; }
        }
        SoundEffect menuSelected2;

        public SoundEffect MenuSelected2
        {
            get { return menuSelected2; }
            set { menuSelected2 = value; }
        }
        
        public int EntrySelected
        {
            get { return entrySelected; }
            set { entrySelected = value; }
        }

        public MenuScreen(Vector2 _offSet)
        {
            this.offSet = _offSet;
        }

        public override void Update(GameTime gameTime)
        {
            menuEntries[entrySelected].Update(this, gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            menuEntries[entrySelected].Draw(this, gameTime); 
        }

        protected virtual void OnSelectEntry()
        {
            menuEntries[entrySelected].OnSelectEntry();
        }

 
        public override void HandleInput(InputState input, GameTime gameTime)
        {
           
            if (input.isMenuSelect())
            {
                OnSelectEntry();
                input.IsActive = true;
                menuSelected1.Play();
            }

            if (input.isMenuUp())
            {
                entrySelected--;
                if (entrySelected < 0)
                    entrySelected = menuEntries.Count - 1;
                menuSelected2.Play();
            }

            if (input.isMenuDown())
            {
                entrySelected++;
                if (entrySelected > menuEntries.Count - 1)
                    entrySelected = 0;
                menuSelected2.Play();
            }
        }
    }
}
