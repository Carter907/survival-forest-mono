using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurvivalForest.Game.Model;

namespace SurvivalForest.Game.View;

public abstract class Sprite<T> where T : Entity
{
    protected Texture2D _texture;


    protected Sprite(Texture2D texture)
    {
        _texture = texture;
    }

    public abstract void Draw(SpriteBatch spriteBatch, T entity);

}