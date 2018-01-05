namespace Core.Result {
    
    public interface IOperator {
        string GetSymbol();
        int Apply(int first, int second);
        
    }
}