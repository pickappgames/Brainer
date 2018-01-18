using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Assets;
using Core.Action;
using Core.Domain.Game;
using Core.Domain.Result;
using Core.Domain.Score;
using Infraestructure.Game;
using Infraestructure.Result;
using Infraestructure.Score;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainComponent : MonoBehaviour {

	public GameObject ResultPrefab;
	public GameObject Operation;
	public Text PlayerText;
	public Image YouLose;
	public Text ScoreText;
	public Text MaxScoreText;
	
	private ResultGenerator resultGenerator;
	private GameRepository gameRepository;
	private IResultRepository resultRepository;
	private GamePresenter gamePresenter;
	private ScoreService scoreService;
	
	private void Awake() {
		YouLose.gameObject.SetActive(false);
		InstanceCache.Flush();
		
		gameRepository = InstanceCache.GetOrInstanciate<InMemoryGameRepository>(()=> new InMemoryGameRepository());
		resultRepository = InstanceCache.GetOrInstanciate<InMemoryResultRepository>(()=> new InMemoryResultRepository());
		scoreService = InstanceCache.GetOrInstanciate<LocalScoreService>(() => new LocalScoreService());
		resultRepository.Clear();
		gameRepository.Clear();
		scoreService.Reset();
		
		gamePresenter = InstanceCache.GetOrInstanciate<GamePresenter>(
			() => {
				resultGenerator = new ResultGenerator(4, new AdditionOperator(), new RandomNumberGenerator(1, 10));
				return new GamePresenter(
					this,
					new CreateGame(gameRepository,
						new FixedInitialNumber(),
						resultGenerator,
						resultRepository),
					new Guess(gameRepository, resultRepository, resultGenerator, scoreService),
					scoreService);
			});

	}

	void Start() {
		gamePresenter.StartPlay();
	}

	public void CreateResult(int currentNumber, GameResults results) {
		PlayerText.text = currentNumber.ToString();
		var gamerResultsValues = results.Results;
		Shuffle(gamerResultsValues);
		var instantiate = Instantiate(ResultPrefab);
		var children = instantiate.gameObject.transform.GetChildCount();
		for (var i = 0; i < children; ++i) {
			var child = instantiate.gameObject.transform.GetChild(i);
			child.GetComponentInChildren<Text>().text = gamerResultsValues[i].Value.ToString();
		}
		var operation = Instantiate(Operation);
		operation.GetComponentInChildren<Text>().text = "+ " + results.MultiplierNumber;
	}

	private static void Shuffle<T>(IList<T> list) {  
		var n = list.Count;  
		while (n > 1) {  
			n--;  
			var k = Random.Range(0, n + 1);  
			var value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}

	public void FinishGame() {
		YouLose.gameObject.SetActive(true);
		StartCoroutine(DoTheDance());
	}

	private IEnumerator DoTheDance() {
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void IncrementScore() {
		var score = ScoreText.text;
		var scoreNumber = int.Parse(score);
		scoreNumber++;
		ScoreText.text = scoreNumber.ToString();
	}

	public void DisplayMaxScore(int maxScore) {
		MaxScoreText.text = maxScore.ToString();
	}
}
