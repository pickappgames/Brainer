using Core.Action;
using Core.Domain.Score;

public class GamePresenter {
    
    private readonly MainComponent mainComponent;
    private readonly CreateGame createGame;
    private readonly Guess guess;
    private readonly ScoreService scoreService;

    public GamePresenter(MainComponent mainComponent, CreateGame createGame, Guess guess, ScoreService scoreService) {
        this.mainComponent = mainComponent;
        this.createGame = createGame;
        this.guess = guess;
        this.scoreService = scoreService;
    }

    public void StartPlay() {
        var brainerGameCreated = createGame.Invoke();
        mainComponent.DisplayMaxScore(scoreService.FindMaxScore());
        mainComponent.CreateResult(brainerGameCreated.Game.GetCurrentNumber(), brainerGameCreated.Results);
    }

    public void Guess(int guessedNumber) {
        var guessResult = guess.Invoke(guessedNumber);
        if (guessResult.IsCorrect()) {
            mainComponent.CreateResult(guessResult.Game.GetCurrentNumber(), guessResult.NewResult);
            mainComponent.IncrementScore();
        }
        else {
            mainComponent.FinishGame();
        }
    }
    
}