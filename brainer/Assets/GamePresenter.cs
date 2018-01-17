using Core.Action;

public class GamePresenter {
    
    private readonly MainComponent mainComponent;
    private readonly CreateGame createGame;
    private readonly Guess guess;

    public GamePresenter(MainComponent mainComponent, CreateGame createGame, Guess guess) {
        this.mainComponent = mainComponent;
        this.createGame = createGame;
        this.guess = guess;
    }

    public void StartPlay() {
        var brainerGameCreated = createGame.Invoke();
        mainComponent.CreateResult(brainerGameCreated.Game.GetCurrentNumber(), brainerGameCreated.Results);
    }

    public void Guess(int guessedNumber) {
        var guessResult = guess.Invoke(guessedNumber);
        if (guessResult.IsCorrect()) {
            mainComponent.CreateResult(guessResult.Game.GetCurrentNumber(), guessResult.NewResult);
        }
        else {
            mainComponent.FinishGame();
        }
    }
    
}