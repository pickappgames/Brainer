using Core.Domain.Score;
using UnityEngine;

namespace Infraestructure.Score {
    public class LocalScoreService : ScoreService {
        
        private int actualScore;
        
        public void IncrementScore() {
            actualScore++;
            var hasMaxScore = PlayerPrefs.HasKey("max_score");
            if (hasMaxScore) {
                var maxScore = PlayerPrefs.GetInt("max_score");
                if (maxScore < actualScore) {
                    PlayerPrefs.SetInt("max_score", actualScore);
                }
            }
            else {
                PlayerPrefs.SetInt("max_score", actualScore);
            }
        }

        public void Reset() {
            actualScore = 0;
        }

        public int FindMaxScore() {
            return PlayerPrefs.HasKey("max_score") ? PlayerPrefs.GetInt("max_score") : 0;
        }
    }
}