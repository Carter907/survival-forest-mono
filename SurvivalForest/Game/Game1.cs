using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using SharpDX;
using SurvivalForest.Game.Sprites;
using MGame = Microsoft.Xna.Framework.Game;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace SurvivalForest.Game;

public class Game1 : MGame
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private List<Sprite> _sprites;
    private OrthographicCamera _camera;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        var playerPos = new Vector2(_graphics.PreferredBackBufferWidth / 2f, _graphics.PreferredBackBufferHeight / 2f);
        var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 400, 240);
        _camera = new OrthographicCamera(viewportAdapter);
        _camera.Move(new Vector2(playerPos.X / 2f, playerPos.Y / 2f));
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _player = new Player(
            Content.Load<Texture2D>("character-atlas"),
            playerPos,
            new Vector2(50, 50),
            200f,
            _camera
        );

        _sprites = new List<Sprite>
        {
            _player,
        };
        for (int i = 0; i < 50; i++)
        {
            var randomX = (int)(Random.Shared.NextFloat(0, 1) * _graphics.PreferredBackBufferWidth);
            var randomY = (int)(Random.Shared.NextFloat(0, 1) * _graphics.PreferredBackBufferHeight);
            var type = i % 20 == 0 ? "dead-tree" : i % 5 == 0 ? "rocks" : "tree";
            _sprites.Add(new ScaledSprite(Content.Load<Texture2D>(type), new Vector2(randomX, randomY),
                new Vector2(50, 50)));
        }
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        foreach (var sprite in _sprites)
        {
            sprite.Update(gameTime, _graphics);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(new Vector3(.15f, .25f, .15f)));
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _camera.GetViewMatrix());
        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }

        _spriteBatch.End();


        base.Draw(gameTime);
    }
}