

using Microsoft.Xna.Framework;
using SurvivalForest.Game.View;

namespace SurvivalForest.Game.Model;

public class PlayerEntity : Entity
{
    
    public float Speed { get; set; }
    public bool IsRunning { get; set; }
    public Vector2 Size { get; set; }
    

    public PlayerEntity(Vector2 position, Vector2 size, float speed, bool isRunning) : base(position)
    {
        Size = size;
        Speed = speed;
        IsRunning = isRunning;
    }

    }