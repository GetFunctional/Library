namespace GF.Games.EntityComponentSystem
{
    public interface IEntity
    {
        TComponent GetComponent<TComponent>() where TComponent : IEntityComponent;
    }
}