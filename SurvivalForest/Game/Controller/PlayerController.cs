using Microsoft.Xna.Framework;
using MonoGame.Extended;
using SurvivalForest.Game.Model;

namespace SurvivalForest.Game.Controller;

public class PlayerController
{
    private PlayerInputHandler _inputHandler;
    public PlayerController(GraphicsDeviceManager graphics)
    {
        _inputHandler = new PlayerInputHandler(graphics);
    }

    public void CheckMovePlayer(PlayerEntity entity, GameTime gameTime, OrthographicCamera camera)
    {
        var commands = _inputHandler.HandleInput(entity, gameTime, camera);

        foreach (var command in commands)
        {
            command.Invoke(entity);
        }
    }
}