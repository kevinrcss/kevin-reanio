namespace DelfostiChallenge.Core.Interfaces
{
    public interface ISecuenciaRepository
    {
        Task<int> GetNextSequenceValueAsync(string sequenceName);
    }
}
