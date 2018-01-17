using Assets;
using Core.Action;
using Core.Domain.Game;
using Core.Domain.Result;
using Infraestructure.Game;
using Infraestructure.Result;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerComponent : MonoBehaviour {
	
	private GamePresenter gamePresenter;
	
	private void Start() {
		gamePresenter = InstanceCache.Get<GamePresenter>();
	}

	void OnTriggerEnter(Collider other) {
		var text = other.gameObject.GetComponentInChildren<Text>().text;
		gamePresenter.Guess(int.Parse(text));
	}

}
