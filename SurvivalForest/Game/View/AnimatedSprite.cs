using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SurvivalForest.Game.Model;

namespace SurvivalForest.Game.View;

public class AnimatedSprite<T> : Sprite<T> where T : Entity
{
    protected AnimationManager AniManager { get; set; }

    public AnimatedSprite(
        Texture2D texture
    ) : base(texture)
    {
    }


    public override void Draw(SpriteBatch spriteBatch, T entity)
    {
        throw new System.NotImplementedException();
    }
}