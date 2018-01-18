namespace Core.Domain.Score {
    public interface ScoreService {
        void IncrementScore();
        int FindMaxScore();
        void Reset();
    }
}