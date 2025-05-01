namespace Code.Progress.SaveLoad
{
    public interface ISaveLoadService
    {
        bool HasSavedProgress { get; }
        void CreateProgress();
        void SaveProgress();
        void LoadProgress();
    }
}