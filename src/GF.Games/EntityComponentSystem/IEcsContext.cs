namespace GF.Games.EntityComponentSystem
{
    public interface IEcsContext
    {
        ComponentRepositoryContext ComponentRepositoryContext { get; }
        ComponentSystemContext ComponentSystemContext { get; }
        ComponentEventContext ComponentEventContext { get; }
    }
}