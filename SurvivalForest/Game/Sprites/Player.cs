using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SurvivalForest.Game.Sprites;

public class Player : AnimatedSprite
{
    private float _speed;
    private Vector2 _size;
    private bool _isRunning;
    private OrthographicCamera _camera;

    public Vector2 Pos
    {
        get { return _position; }
        set { _position = value; }
    }

    public Player(Texture2D texture, Vector2 position, Vector2 size, float speed, OrthographicCamera camera) :
        base(texture, position, size)
    {
        _size = size;
        _speed = speed;
        _camera = camera;
        _isRunning = false;
        AniManager = new AnimationManager(texture, 1, 3, 200);
        Pos = position;
    }

    public override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
    {
        AniManager.Update(gameTime, () =>
        {
            if (_isRunning && AniManager.CurrentFrame < AniManager.TotalFrames - 1)
            {
                AniManager.CurrentFrame++;
            }
            else if (AniManager.CurrentFrame == AniManager.TotalFrames - 1)
            {
                AniManager.CurrentFrame = 1;
            }
            else
                AniManager.CurrentFrame = 0;
        });


        var cameraMove = Vector2.Zero;
        _isRunning = false;
        var kstate = Keyboard.GetState();
        if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
        {
            _position.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            cameraMove.Y -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
            
        }

        if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
        {
            _position.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            cameraMove.Y += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
        {
            _position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            cameraMove.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
        {
            _position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            cameraMove.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _isRunning = true;
        }

        if (_position.X > graphics.PreferredBackBufferWidth - _size.X / 2)
        {
            _position.X = graphics.PreferredBackBufferWidth - _size.X / 2;
            cameraMove.X = 0;
        }
        else if (_position.X < _size.X / 2)
        {
            _position.X = _size.X / 2;
            cameraMove.X = 0;
        }

        if (_position.Y > graphics.PreferredBackBufferHeight - _size.Y / 2)
        {
            _position.Y = graphics.PreferredBackBufferHeight - _size.Y / 2;
            cameraMove.Y = 0;
        }
        else if (_position.Y < _size.Y / 2)
        {
            _position.Y = _size.Y / 2;
            cameraMove.Y = 0;
        }
        

        _camera.Move(cameraMove);
    }

    public override void Draw(SpriteBatch batch)
    {
        batch.Draw(_texture,
            _position,
            AniManager.SourceRectangle(),
            Color.White,
            0f,
            new Vector2(AniManager.SourceRectangle().Width / 2f, AniManager.SourceRectangle().Height / 2f),
            new Vector2(_size.X / AniManager.SourceRectangle().Width, _size.Y / AniManager.SourceRectangle().Height),
            SpriteEffects.None,
            0f);
    }
}