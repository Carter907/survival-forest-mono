using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SurvivalForest.Game.Model;

namespace SurvivalForest.Game.Controller;

public interface InputHandler<T> where T : Entity
{

    public List<EventCommand<T>> HandleInput(T tEntity, GameTime gameTime, OrthographicCamera camera);
}