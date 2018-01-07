namespace Core.Result {
    public interface ResultRepository {

        GameResults Find();

        void Put(GameResults newResults);
    }
}