using System.Collections.Generic;
using System.Linq;
using Core.Domain.Result;

namespace Infraestructure.Result {
    
    public class InMemoryResultRepository : IResultRepository {

        private readonly List<GameResults> results = new List<GameResults>();
        
        public GameResults Find() {
            return results.First();
        }

        public void Put(GameResults newResults) {
            results.Add(newResults);
        }

        public void Clear() {
            results.Clear();
        }
    }
}