namespace Models.DTOs
{
    public abstract class DTO<T> where T : class
    {
        public abstract void ToModel(T model);
        public abstract T ToModel();
    }
}