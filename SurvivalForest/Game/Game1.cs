using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using SurvivalForest.Game.Controller;
using SurvivalForest.Game.Model;
using SurvivalForest.Game.View;
using MGame = Microsoft.Xna.Framework.Game;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace SurvivalForest.Game;

public class Game1 : MGame
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private PlayerEntity _player;
    private PlayerController _playerController;
    private PlayerSprite _playerSprite;
    private OrthographicCamera _camera;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        var playerPos = new Vector2(_graphics.PreferredBackBufferWidth / 2f, _graphics.PreferredBackBufferHeight / 2f);
        var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 400, 240);
        _camera = new OrthographicCamera(viewportAdapter);
        _camera.Move(new Vector2(playerPos.X / 2f, playerPos.Y / 2f));
        _playerController = new PlayerController(_graphics);
        _player = new PlayerEntity(
            new Vector2(
                _graphics.PreferredBackBufferWidth / 2f,
                _graphics.PreferredBackBufferHeight / 2f
            ),
            new Vector2(50, 50),
            200f,
            true
        );


        _spriteBatch = new SpriteBatch(GraphicsDevice);
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // for (int i = 0; i < 50; i++)
        // {
        //     
        //     var randomX = (int)(Random.Shared.NextFloat(0, 1) * _graphics.PreferredBackBufferWidth);
        //     var randomY = (int)(Random.Shared.NextFloat(0, 1) * _graphics.PreferredBackBufferHeight);
        //     var type = i % 20 == 0 ? "dead-tree" : i % 5 == 0 ? "rocks" : "tree";
        //     
        // }

        _playerSprite = new PlayerSprite(
            Content.Load<Texture2D>("character-atlas")
        );
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _playerController.CheckMovePlayer(_player, gameTime, _camera);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(new Vector3(.15f, .25f, .15f)));
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _camera.GetViewMatrix());
        
        _playerSprite.Draw(_spriteBatch, _player);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}