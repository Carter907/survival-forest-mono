using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalForest.Game.Sprites;

public abstract class Sprite
{
    protected Texture2D _texture;
    protected Vector2 _position;

    protected Sprite(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public abstract void Draw(SpriteBatch spriteBatch);

    public abstract void Update(GameTime gameTime, GraphicsDeviceManager graphics);
}