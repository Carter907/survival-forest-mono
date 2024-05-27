﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX;
using SurvivalForest.Sprites;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace SurvivalForest;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private List<Sprite> _sprites;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _player = new Player(
            Content.Load<Texture2D>("character-atlas"),
            new Vector2(_graphics.PreferredBackBufferWidth / 2f, _graphics.PreferredBackBufferHeight / 2f),
            new Vector2(50, 50),
            100f
        );
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _sprites = new List<Sprite> { 
            _player,
        };
        for (int i = 0; i < 50; i++)
        {
            var randomX = (int)(Random.Shared.NextFloat(0, 1) * _graphics.PreferredBackBufferWidth);
            var randomY = (int)(Random.Shared.NextFloat(0, 1) * _graphics.PreferredBackBufferHeight);
            _sprites.Add(new ScaledSprite(Content.Load<Texture2D>("tree"), new Vector2(randomX, randomY), new Vector2(50, 50)));
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
        GraphicsDevice.Clear(new Color(new Vector3(.1f, .2f, .1f)));
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}