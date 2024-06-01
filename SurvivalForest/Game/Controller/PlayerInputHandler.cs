using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SurvivalForest.Game.Model;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace SurvivalForest.Game.Controller;

public class PlayerInputHandler : InputHandler<PlayerEntity>
{
    private GraphicsDeviceManager _graphics;

    public PlayerInputHandler(GraphicsDeviceManager graphics)
    {
        _graphics = graphics;
    }

    public List<EventCommand<PlayerEntity>> HandleInput(PlayerEntity entity, GameTime gameTime,
        OrthographicCamera camera)
    {
        var eventCommands = new List<EventCommand<PlayerEntity>>();
        var kstate = Keyboard.GetState();
        entity.IsRunning = false;
        var displacement = Vector2.Zero;

        if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.W))
        {
            displacement.Y -= entity.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            entity.IsRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.S))
        {
            displacement.Y += entity.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            entity.IsRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.A))
        {
            displacement.X -= entity.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            entity.IsRunning = true;
        }

        if (kstate.IsKeyDown(Keys.Right) || kstate.IsKeyDown(Keys.D))
        {
            displacement.X += entity.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            entity.IsRunning = true;
        }

        if (entity.Position.X > _graphics.PreferredBackBufferWidth - entity.Size.X / 2)
        {
            displacement = Vector2.Zero;
        }
        else if (entity.Position.X < entity.Size.X / 2)
        {
            displacement = Vector2.Zero;
        }

        if (entity.Position.Y > _graphics.PreferredBackBufferHeight - entity.Size.Y / 2)
        {
            displacement = Vector2.Zero;
        }
        else if (entity.Position.Y < entity.Size.Y / 2)
        {
            displacement = Vector2.Zero;
        }


        camera.Move(displacement);
        eventCommands.Add(playerEntity =>
        {

            playerEntity.Position += displacement;
        });

        return eventCommands;
    }
}