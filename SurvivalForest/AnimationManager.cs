using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SurvivalForest;

public class AnimationManager
{
    public int MillisPerFrame { get; set; }
    public int MilliSinceLastFrame { get; set; }
    public int CurrentFrame { get; set; }
    public int TotalFrames { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    public Texture2D Texture { get; set; }
    public Rectangle SourceRectangle
    {
        get
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            return new Rectangle(width * column, height * row, width, height); 
        }
       
    }

    public AnimationManager(Texture2D texture, int rows, int columns, int millisPerFrame)
    {
        Texture = texture;
        Rows = rows;
        Columns = columns;
        MillisPerFrame = millisPerFrame;
        CurrentFrame = 0;
        MilliSinceLastFrame = 0;
        TotalFrames = Rows * Columns;
    }

    public delegate void FrameCallback();
    public void Update(GameTime gameTime, FrameCallback callback)
    {
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 1;
        if (gameTime.TotalGameTime.TotalMilliseconds > MilliSinceLastFrame + MillisPerFrame)
        {
            MilliSinceLastFrame = (int)gameTime.TotalGameTime.TotalMilliseconds;
            
            callback.Invoke();
        }
    }
}