using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SurvivalForest;

public class Game1 : Game
{
    readonly GraphicsDeviceManager _graphics;
    SpriteBatch _spriteBatch;
    private Player player;
    private float playerSpeed;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player = new Player(
            Content.Load<Texture2D>("character"),
            new Vector2(_graphics.PreferredBackBufferWidth/2f, _graphics.PreferredBackBufferHeight/2f),
            new Vector2(100, 100)
        )
        {
            Speed = 400f,
        };
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        var kstate = Keyboard.GetState();
        player.Update(gameTime, _graphics, kstate);
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Chartreuse);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        player.Draw(_spriteBatch);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}