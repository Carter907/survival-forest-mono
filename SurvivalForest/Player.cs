using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SurvivalForest;

public class Player : Sprite
{
    public float Speed { get; set; }
    public Player(Texture2D texture, Vector2 position, Vector2 size) : 
        base(texture: texture, position, size)
    {
        
    }

    public void Update(GameTime gameTime, GraphicsDeviceManager graphics, KeyboardState kstate)
    {
        if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
        {
            _position.Y -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
        {
            _position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        } 
        if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
        {
            _position.X -= Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
        {
            _position.X += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
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

    public void Draw(SpriteBatch batch)
    {
        batch.Draw(
            _texture,
            _position,
            new Rectangle(0,0,(int)_size.X, (int)_size.Y),
            Color.White,
            0f,
            new Vector2(_texture.Width/2f, _texture.Height/2f),
            Vector2.One,
            SpriteEffects.None,
            0f
            );
    }
}