using System;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SurvivalForest;

public class Player : AnimatedSprite
{
    private float _speed;
    private Vector2 _size;
    private bool _isRunning;

    public Player(Texture2D texture, Vector2 position, Vector2 size, float speed) :
        base(texture, position, size)
    {
        _size = size;
        _speed = speed;
        _isRunning = false;
        AniManager = new AnimationManager(texture, 1, 4, 50);
        
    }

    public override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
    {
        
        AniManager.Update(gameTime, () =>
        {
            if (_isRunning)
                AniManager.CurrentFrame++;
            else
                AniManager.CurrentFrame = 0;
        });

        _isRunning = false;
        var kstate = Keyboard.GetState();
        if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
        {
            _position.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
        {
            _position.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
        {
            _position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
        {
            _position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (_position.X > graphics.PreferredBackBufferWidth - _size.X / 2)
        {
            _position.X = graphics.PreferredBackBufferWidth - _size.X / 2;
        }
        else if (_position.X < _size.X / 2)
        {
            _position.X = _size.X / 2;
        }

        if (_position.Y > graphics.PreferredBackBufferHeight - _size.Y / 2)
        {
            _position.Y = graphics.PreferredBackBufferHeight - _size.Y / 2;
        }
        else if (_position.Y < _size.Y / 2)
        {
            _position.Y = _size.Y / 2;
        }
    }

    public override void Draw(SpriteBatch batch)
    {
        

        batch.Draw(_texture,
            _position,
            AniManager.SourceRectangle,
            Color.White,
            0f,
            new Vector2(AniManager.SourceRectangle.Width / 2f, AniManager.SourceRectangle.Height / 2f),
            new Vector2(_size.X / AniManager.SourceRectangle.Width, _size.Y / AniManager.SourceRectangle.Height),
            SpriteEffects.None,
            0f);
    }
}