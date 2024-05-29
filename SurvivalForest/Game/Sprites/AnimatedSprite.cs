using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalForest.Game.Sprites;

public class AnimatedSprite : ScaledSprite
{
    protected AnimationManager AniManager { get; set; }

    public AnimatedSprite(
        Texture2D texture,
        Vector2 position,
        Vector2 size
    ) : base(texture, position, size)
    {
    }
}