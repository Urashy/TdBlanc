namespace TdBlanc.Models.Strategy
{
    public interface IReferenceStrategy
    {
        string GenerateReference(string baseReference);
    }

    // Strategy pour référence normale
    public class NormalReferenceStrategy : IReferenceStrategy
    {
        public string GenerateReference(string baseReference)
        {
            return baseReference;
        }
    }

    // Strategy pour référence privée (masquée)
    public class PrivateReferenceStrategy : IReferenceStrategy
    {
        public string GenerateReference(string baseReference)
        {
            return "******";
        }
    }

    // Context qui utilise les strategies
    public class ReferenceContext
    {
        private IReferenceStrategy _strategy;

        public void SetStrategy(IReferenceStrategy strategy)
        {
            _strategy = strategy;
        }

        public string ApplyReference(string baseReference)
        {
            return _strategy?.GenerateReference(baseReference) ?? baseReference;
        }
    }
}