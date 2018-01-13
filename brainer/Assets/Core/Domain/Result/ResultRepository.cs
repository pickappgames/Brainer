namespace Core.Domain.Result {
    public interface IResultRepository {
        GameResults Find();

        void Put(GameResults newResults);

        void Clear();
    }
}