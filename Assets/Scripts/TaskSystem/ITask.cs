namespace TaskSystem
{
    public interface ITask
    {
        string taskName { get; }
        bool IsCompleted { get; }
        bool IsFailed { get; }
        int rewardPoint { get; }

        void CheckProgress(GameTime gameTime);
    }
}