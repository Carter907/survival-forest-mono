using Microsoft.Xna.Framework.Graphics;
using SurvivalForest.Game.Model;

namespace SurvivalForest.Game.View;

public class TreeSprite : Sprite<TreeEntity>
{
    public TreeSprite(Texture2D texture) : base(texture)
    {
    }

    public override void Draw(SpriteBatch spriteBatch, TreeEntity entity)
    {
        throw new System.NotImplementedException();
    }
}