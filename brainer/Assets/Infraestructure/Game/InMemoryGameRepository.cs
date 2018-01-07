using Core.Domain.Game;

namespace Infraestructure.Game {
    
    public class InMemoryGameRepository : GameRepository {
        
        private BrainerGame game;
        
        public BrainerGame Find() {
            return game;
        }

        public void Put(BrainerGame game) {
            this.game = game;
        }
    }
}