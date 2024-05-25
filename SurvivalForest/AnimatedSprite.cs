using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalForest;

public class AnimatedSprite : ScaledSprite
{
    protected Texture2D Texture { get; set; }
    protected int Rows { get; set; }
    protected int Columns { get; set; }
    protected int _millisPerFrame;
    protected int _milliSinceLastFrame;
    protected int _currentFrame;
    protected int _totalFrames;
    
    public AnimatedSprite(
        Texture2D texture,
        Vector2 position,
        Vector2 size,
        int rows,
        int columns,
        int millisPerFrame
        ) : base(texture, position, size)
    {
        Texture = texture;
        Rows = rows;
        Columns = columns;
        _millisPerFrame = millisPerFrame;
        _currentFrame = 0;
        _milliSinceLastFrame = 0;
        _totalFrames = Rows * Columns;
    }


}