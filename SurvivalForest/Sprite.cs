using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalForest;

public class Sprite
{
    protected Texture2D _texture;
    protected Vector2 _position;
    protected Vector2 _size;

    protected Sprite(Texture2D texture, Vector2 position, Vector2 size)
    {
        _texture = texture;
        _position = position;
        _size = size;
    }
}