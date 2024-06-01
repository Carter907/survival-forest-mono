using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using SurvivalForest.Game.Model;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SurvivalForest.Game.View;

public class PlayerSprite : AnimatedSprite<PlayerEntity>
{
    public PlayerSprite(Texture2D texture) :
        base(texture)
    {
        
        AniManager = new AnimationManager(texture, 1, 3, 200);
        
    }

    public override void Draw(SpriteBatch batch, PlayerEntity playerEntity)
    {
        batch.Draw(_texture,
            playerEntity.Position,
            AniManager.SourceRectangle(),
            Color.White,
            0f,
            new Vector2(AniManager.SourceRectangle().Width / 2f, AniManager.SourceRectangle().Height / 2f),
            new Vector2(playerEntity.Size.X / AniManager.SourceRectangle().Width, playerEntity.Size.Y / AniManager.SourceRectangle().Height),
            SpriteEffects.None,
            0f);
    }
}