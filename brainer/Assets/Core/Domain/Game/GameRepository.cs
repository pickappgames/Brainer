namespace Core.Domain.Game {
    public interface GameRepository {
        BrainerGame Find();
        void Put(BrainerGame game);
        void Clear();
    }
}