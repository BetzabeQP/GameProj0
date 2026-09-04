using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Game_Proj0
{
    public enum Direction
    {
        Down = 0,
        Right = 1,
        Up = 2,
        Left = 3
    }
    public class BirdSprite
    {
        private double directionTimer;
        private Texture2D texture;
        public Direction Direction; 

        private short frame = 0;

        private double changeFrame;

        public Vector2 Postion;
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Bird");
        }
        public void Update(GameTime gameTime)
        {
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if(directionTimer > 2.0)
            {
                switch(Direction)
                {
                    case Direction.Up:
                        Direction = Direction.Down;
                        break;
                    case Direction.Down:
                        Direction = Direction.Up;
                        break;
                    case Direction.Right:
                        Direction = Direction.Left;
                        break;
                    case Direction.Left:
                        Direction = Direction.Right;
                        break;
                }
                directionTimer -= 2.0;
            }

                  
            switch (Direction)
            {
                case Direction.Up:
                    Postion += new Vector2(0,-1) * 100 *(float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Down:
                    Postion += new Vector2(0, 1) * 100 *(float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Left:
                    Postion += new Vector2(-1,0) * 100 *(float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Postion += new Vector2(1,0) * 100 *(float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            changeFrame += gameTime.ElapsedGameTime.TotalSeconds;
            if(changeFrame > 0.5)
            {
                frame++;
                if(frame > 1) frame = 0;
                changeFrame -= 0.5;
            }
            Rectangle source = new Rectangle(0,0,32,32);
            switch(Direction)
            {
                case Direction.Down:
                    source.Y = 32;
                    break;
                case Direction.Up:
                    source.X = 32;
                    source.Y = 32;
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    source.X = 32;
                    break;   
            }
            
            spriteBatch.Draw(texture, Postion, source,Color.White);
        }
    }
}