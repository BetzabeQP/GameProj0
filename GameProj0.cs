using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Game_Proj0;

public class GameProj0 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private TreeSprite tree;
    private BirdSprite[] birds;
    private BearSprite bear;
    private SpriteFont robotoThin;

    private bool temptTest = false;
    public GameProj0()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        bear = new();
        tree = new();
        birds = new BirdSprite[]
        {
            new BirdSprite(){Postion = new Vector2(200, 200), Direction = Direction.Down},
            new BirdSprite(){Postion = new Vector2(100, 100), Direction = Direction.Right}
        };
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        bear.LoadContent(Content);
        tree.LoadContent(Content);
        foreach(var bird in birds) bird.LoadContent(Content);
        robotoThin = Content.Load<SpriteFont>("Roboto");        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        bear.Color = Color.White;
        bear.Update(gameTime);
        temptTest = false;
        foreach(var bird in birds) {
            bird.Update(gameTime);
            if(bird.Collides(bear.bearBox)) temptTest = true;
        }
        if(temptTest) bear.Color = Color.Red;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        foreach(var bird in birds) bird.Draw(gameTime, _spriteBatch);
        tree.Draw(gameTime, _spriteBatch);
        bear.Draw(gameTime, _spriteBatch);
        //if(temptTest == true) _spriteBatch.DrawString(robotoThin,"Colided", new Vector2(0,0), Color.OrangeRed );
        //_spriteBatch.DrawString(robotoThin, $"Press the {Keys.Escape} button to exit the game", new Vector2(0,0), Color.OrangeRed);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
