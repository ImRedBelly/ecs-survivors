using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
    public class EndOfFrameExitState : IState, IUpdateable
    {
        private Promise _exitPromise;
        private bool ExitWasRequested => _exitPromise != null;

        public virtual void Enter()
        {
        }


        protected virtual void OnUpdate()
        {
        }


        protected virtual void ExitOnEndOfFrame()
        {
        }

        IPromise IExitableState.BeginExit()
        {
            _exitPromise = new Promise();
            return _exitPromise;
        }

        void IExitableState.EndExit()
        {
            ExitOnEndOfFrame();
            _exitPromise = null;
        }

        void IUpdateable.Update()
        {
            if (!ExitWasRequested)
            {
                OnUpdate();
            }

            if (ExitWasRequested)
            {
                ResoleExitPromise();
            }
        }

        private void ResoleExitPromise()
        {
            _exitPromise?.Resolve();
        }
    }
}