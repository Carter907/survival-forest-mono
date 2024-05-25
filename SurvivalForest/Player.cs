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
        base(texture, position, size, 1, 4, 200)
    {
        _size = size;
        _speed = speed;
        _isRunning = false;
    }

    public override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
    {
        
        if (_currentFrame == _totalFrames)
            _currentFrame = 1;
        if (gameTime.TotalGameTime.TotalMilliseconds > _milliSinceLastFrame+_millisPerFrame)
        {
            _milliSinceLastFrame = (int)gameTime.TotalGameTime.TotalMilliseconds;
            if (_isRunning)
                _currentFrame++;
            else
                _currentFrame = 0;
        }

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
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        int row = _currentFrame / Columns;
        int column = _currentFrame % Columns;

        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

        batch.Draw(_texture,
            _position,
            sourceRectangle,
            Color.IndianRed,
            0f,
            new Vector2(sourceRectangle.Width / 2f, sourceRectangle.Height / 2f),
            new Vector2(_size.X / sourceRectangle.Width, _size.Y / sourceRectangle.Height),
            SpriteEffects.None,
            0f);
    }
}