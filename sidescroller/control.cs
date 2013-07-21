using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace sidescroller
{
    class control
    {
        Game1 game;


        public control(Game1 game) : base ()
        {
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState currentState;
            currentState = Keyboard.GetState();

            //menu and option keys
            if (currentState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

            //control keys

            ///////
            ///Left
            ///////

            if (currentState.IsKeyDown(Keys.Left))
            {
                //game.character.charMove++;

                //game.character.left = true;
                //game.character.right = false;
                //game.character.last = 1;
                
                if (game.character.animation < 120)
                {
                    game.character.animation = game.character.animation + 40;
                }
                else
                {
                    game.character.animation = 0;
                }

                game.character.left();
            }

            if (currentState.IsKeyDown(Keys.Space) && currentState.IsKeyDown(Keys.Left))
            {
                if (game.character.animation < 120)
                {
                    game.character.animation = game.character.animation + 40;
                }
                else
                {
                    game.character.animation = 0;
                }

                game.character.jumpLeft();
            }

            ///////
            //Right
            ///////

            if (currentState.IsKeyDown(Keys.Right))
            {
                //game.character.charMove--;

                //game.character.right = true;
                //game.character.left = false;
                //game.character.last = 2;

                if (game.character.animation < 120)
                {
                    game.character.animation = game.character.animation + 40;
                }
                else
                {
                    game.character.animation = 0;
                }

                game.character.right();
            }

            if (currentState.IsKeyDown(Keys.Space) && currentState.IsKeyDown(Keys.Right))
            {
                if (game.character.animation < 120)
                {
                    game.character.animation = game.character.animation + 40;
                }
                else
                {
                    game.character.animation = 0;
                }

                game.character.jumpRight();
            }
        }
    }
}
