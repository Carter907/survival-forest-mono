using SurvivalForest.Game.Model;

namespace SurvivalForest.Game;

public delegate void EventCommand<in T>(T entity) where T : Entity;