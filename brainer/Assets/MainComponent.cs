using System.Collections;
using System.Collections.Generic;
using Core.Action;
using Core.Domain.Game;
using Core.Domain.Result;
using Infraestructure.Game;
using Infraestructure.Result;
using UnityEngine;
using UnityEngine.UI;

public class MainComponent : MonoBehaviour {

	public GameObject ResultPrefab;
	public GameObject Player;
	public GameObject Operation;
	
	private ResultGenerator resultGenerator;
	private GameRepository gameRepository;
	private IResultRepository resultRepository;
	
	void Start() {
		gameRepository = new InMemoryGameRepository();
		resultRepository = new InMemoryResultRepository();
		new CreateGame(gameRepository, new FixedInitialNumber(), new ResultGenerator(4, new AdditionOperator(), new RandomNumberGenerator(1, 10)), resultRepository).Invoke();
		InstanciateFirstResult();
		InvokeRepeating("InstanciateResult", 5f, 5f);  //1s delay, repeat every 1s
	}

	private void InstanciateFirstResult() {
		Player.GetComponentInChildren<Text>().text = gameRepository.Find().GetCurrentNumber().ToString();
		var gameResults = resultRepository.Find();
		var gamerResultsValues = gameResults.Results;
		Shuffle(gamerResultsValues);
		var instantiate = Instantiate(ResultPrefab);
		int children = instantiate.gameObject.transform.GetChildCount();
		for (var i = 0; i < children; ++i) {
			var child = instantiate.gameObject.transform.GetChild(i);
			child.GetComponentInChildren<Text>().text = gamerResultsValues[i].Value.ToString();
		}
		var operation = Instantiate(Operation);
		operation.GetComponentInChildren<Text>().text = "+ " + gameResults.MultiplierNumber;
	}

	void InstanciateResult() {
		Player.GetComponentInChildren<Text>().text = gameRepository.Find().GetCurrentNumber().ToString();
		resultGenerator = new ResultGenerator(4, new AdditionOperator(), new RandomNumberGenerator(1, 20));
		var gameResults = resultGenerator.Generate(gameRepository.Find().GetCurrentNumber());
		var gamerResultsValues = gameResults.Results;
		Shuffle(gamerResultsValues);
		var instantiate = Instantiate(ResultPrefab);
		int children = instantiate.gameObject.transform.GetChildCount();
		for (var i = 0; i < children; ++i) {
			var child = instantiate.gameObject.transform.GetChild(i);
			child.GetComponentInChildren<Text>().text = gamerResultsValues[i].Value.ToString();
		}

		var operation = Instantiate(Operation);
		operation.GetComponentInChildren<Text>().text = "+ " + gameResults.MultiplierNumber;
	}
	
	public static void Shuffle<T>(IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0, n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
}
