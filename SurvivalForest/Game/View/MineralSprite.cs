using Microsoft.Xna.Framework.Graphics;
using SurvivalForest.Game.Model;

namespace SurvivalForest.Game.View;

public class MineralSprite : Sprite<MineralEntity>
{
    public MineralSprite(Texture2D texture) : base(texture)
    {
    }

    public override void Draw(SpriteBatch spriteBatch, MineralEntity entity)
    {
        throw new System.NotImplementedException();
    }
}