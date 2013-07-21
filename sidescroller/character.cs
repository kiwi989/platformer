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
    public class character
    {
        Game1 game;

        Texture2D chara;

        //movement counters
        public int charMove = 0, moveSpeed = 10;
        public int animation = 0;
        public int last = 1;

        //animation counters
        private bool drawLeft = true, drawRight = false, drawDead = false;
        private bool drawLeftJump = false, drawRightJump = false;

        //grvity stuff
        float tracker = 0, runSpeed = 100;

        //position
        int positionX = 400, positionY = 400;

        //keeps tabs on if the char is on ground or not
        bool isOnGround = false, isDead = false; 

        public character(Game1 game)
            : base()
        {
            this.game = game;
        }

        public void loadContent()
        {
            chara = game.Content.Load<Texture2D>("textures/players/char");
        }

        public void Update()
        {
            physics();
        }

        public void left()
        {

            if (isOnGround == true && isDead == false)
            {
                charMove++;
                game.environment.skyMove++;
                game.environment.backdropMove++;

                drawLeft = true;
                drawRight = false;
                drawRightJump = false;
                drawLeftJump = false;
            }

        }

        public void right()
        {
            if (isOnGround == true && isDead == false)
            {
                charMove--;
                game.environment.skyMove--;
                game.environment.backdropMove--;

                drawLeft = false;
                drawRight = true;
                drawRightJump = false;
                drawLeftJump = false;
            }
        }

        public void jumpLeft()
        {
            if (isOnGround == false && isDead == false)
            {
                charMove++;
                game.environment.skyMove++;
                game.environment.backdropMove++;

                drawLeft = false;
                drawRight = false;
                drawRightJump = false;
                drawLeftJump = true;
            }
        }

        public void jumpRight()
        {
            if (isOnGround == false && isDead == false)
            {
                charMove--;
                game.environment.skyMove--;
                game.environment.backdropMove--;

                drawLeft = false;
                drawRight = false;
                drawRightJump = true;
                drawLeftJump = false;
            }
        }

        public void jump()
        {
            //if (jumpDis < maxhight && jumpUp)
            //{
            //    jumpDis += jumpSpeed;
            //}
            //else
            //{
            //    jumpDis -= jumpSpeed;
            //    //tell to fall (will shake at top of jump without)
            //    jumpUp = false;
            //}
            ////returns the bools to default
            //if (jumpDis <= 0)
            //{
            //    jumpUp = true;
            //    jump = false;
            //}
        }

        private void physics()
        {
            //float elTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //tracker += elTime;  

            if (isOnGround == false)
            {
                positionY += game.environment.gravity;
                //tracker -= runSpeed;
                if (positionY == 650)
                {
                    isOnGround = true;
                }
            }
        }
            
        public void Draw(GameTime gameTime)
        {
            game.spriteBatch.Begin();


            if (drawLeft == true)
            {
                game.spriteBatch.Draw(chara, new Rectangle(positionX, positionY, 40, 60), new Rectangle(animation, 60, 40, 60), Color.White);
            }
            else if (drawRight == true)
            {
                game.spriteBatch.Draw(chara, new Rectangle(positionX, positionY, 40, 60), new Rectangle(animation, 0, 40, 60), Color.White);
            }
            else if (drawLeftJump == true)
            {
                game.spriteBatch.Draw(chara, new Rectangle(positionX, positionY, 40, 60), new Rectangle(0, 0, 40, 60), Color.White);
            }
            else if (drawRightJump == true)
            {
                game.spriteBatch.Draw(chara, new Rectangle(positionX, positionY, 40, 60), new Rectangle(40, 0, 40, 60), Color.White);
            }

            game.spriteBatch.End();
        }

    }
}
