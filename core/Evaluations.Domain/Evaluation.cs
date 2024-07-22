namespace Evaluations.Domain{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }  
        public Guid ProductId { get; set; }
        public int Value { get; set; }
    }
}