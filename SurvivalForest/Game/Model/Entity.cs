using Microsoft.Xna.Framework;

namespace SurvivalForest.Game.Model;

public abstract class Entity
{
    public Vector2 Position;

    public Entity(Vector2 position)
    {
        Position = position;
    }
    
}