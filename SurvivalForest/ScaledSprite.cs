using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalForest;

public class ScaledSprite : Sprite
{
    protected Vector2 _size;
    public ScaledSprite(Texture2D texture, Vector2 position, Vector2 size) : base(texture, position)
    {
        _size = size;
    }

    public override void Draw(SpriteBatch batch)
    {
        batch.Draw(
            _texture,
            _position,
            null,
            Color.White,
            0f,
            new Vector2(_texture.Width / 2f, _texture.Height / 2f),
            new Vector2(_size.X/_texture.Width, _size.Y/_texture.Height),
            SpriteEffects.None,
            0f
        );
    }

    public override void Update(GameTime gameTime, GraphicsDeviceManager graphics)
    {
    }
}