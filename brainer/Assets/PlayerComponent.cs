using Assets;
using Core.Action;
using Core.Domain.Result;
using Infraestructure.Game;
using Infraestructure.Result;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour {
	private InMemoryGameRepository gameRepository;
	private InMemoryResultRepository resultRepository;
	
	private void Awake() {
		gameRepository = InstanceCache.GetOrInstanciate<InMemoryGameRepository>(()=> new InMemoryGameRepository());
		resultRepository = InstanceCache.GetOrInstanciate<InMemoryResultRepository>(()=> new InMemoryResultRepository());	
	}

	void OnTriggerEnter(Collider other) {
		var text = other.gameObject.GetComponentInChildren<Text>().text;
		var guessResult = new Guess(gameRepository, resultRepository,
			new ResultGenerator(4, new AdditionOperator(), new RandomNumberGenerator(1, 10))).Invoke(int.Parse(text));
		if (!guessResult.IsCorrect()) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			resultRepository.Clear();
		}
	}

}
