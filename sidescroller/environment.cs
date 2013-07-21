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
    public class environment
    {
        Game1 game;

        Texture2D land, clouds;

        public int skyMove = 0, backdropMove = 0;
        public int gravity = 1;
        
        public environment(Game1 game) : base ()
        {
            this.game = game;
        }

        public void LoadContent()
        {
            land = game.Content.Load<Texture2D>("textures/environment/land");
            clouds = game.Content.Load<Texture2D>("textures/environment/clouds");
        }

        public void Update(GameTime gameTime)
        {
            if (game.character.charMove > 0)
            {
                game.character.charMove -= 60;
            }
            if (game.character.charMove < -60)
            {
                game.character.charMove += 60;
            }
            if (game.environment.skyMove > 0)
            {
                game.environment.skyMove -= 1594;
            }
            if (game.environment.skyMove < -1594)
            {
                game.environment.skyMove += 1594;
            }
        }

        public void Draw(GameTime gametime)
        {
            game.spriteBatch.Begin();

            for (int i = -1; i < ((1024 / 60) + 2); i++)
            {
                game.spriteBatch.Draw(land, new Rectangle(0 + (i * 60) + game.character.charMove, 708, 60, 60), Color.White);
            }

            for (int i = -1; i < ((1024 / 60) + 2); i++)
            {
                game.spriteBatch.Draw(clouds, new Rectangle(0 + (i * 1594) + game.environment.skyMove, 0, 1594, 438), Color.White);
            }

            Update(gametime);

            game.spriteBatch.End();
        }
    }
}
