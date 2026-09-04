using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Game_Proj0{
    public class TreeSprite
    {
    private Texture2D texture;
    public void LoadContent(ContentManager content)
    {
        texture = content.Load<Texture2D>("Tree");
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture,new Vector2(400,200),Color.White);
    }
    }
}