namespace TaskSystem
{
    public interface ITask
    {
        bool IsCompleted { get; }
        bool IsFailed { get; }

        void CheckProgress(GameTime gameTime);
    }
}