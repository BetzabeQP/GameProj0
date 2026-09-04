using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Game_Proj0{

    public class BearSprite
    {
    private KeyboardState keyboardState;
    private Texture2D texture;

    private Vector2 position = new Vector2(200, 200);

    private bool flipped;
    /// <summary>
    /// The color to blend of the ghost
    /// </summary>
    public Color Color {get;set;} = Color.White;

    public void LoadContent(ContentManager content)
    {
        texture = content.Load<Texture2D>("Bear");
    }

    public void Update(GameTime gameTime)
    {
        keyboardState = Keyboard.GetState();
        if(keyboardState.IsKeyDown(Keys.Up)|| keyboardState.IsKeyDown(Keys.W)) position += new Vector2(0, -1);
        if(keyboardState.IsKeyDown(Keys.Down)|| keyboardState.IsKeyDown(Keys.S)) position += new Vector2(0, 1);
        if(keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
        {
            position += new Vector2(-1,0);
            flipped = true;
        }
        if(keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
        {
            position += new Vector2(1,0);
            flipped = false;
        }
    }
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        spriteBatch.Draw(texture, position, null,Color, 0,new Vector2(32, 32), 0.9f, spriteEffects, 0);
    }
    }    
}