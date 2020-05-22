namespace Project.Repository.Abstract
{
    public interface IIdentifiable<T>
    {
        T GetId();
        void SetId(T id);
    }
}
