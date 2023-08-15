using System.Reactive.Linq;

namespace CardReader.Core.Redux
{
    public class Store<T> : IStore<T>
    {
        private event Action<T>? StateChanged; 

        private readonly IObservable<T> source;

        public T State { get; private set; }

        private readonly Reducer reducer;

        public delegate T Reducer(T state, IAction action);

        public Store(Reducer reducer, T state)
        {
            source = Observable.FromEvent<T>(
                a => StateChanged += a,
                a => StateChanged -= a);

            this.reducer = reducer;
            State = state;
        }

        public void Dispatch(IAction action)
        {
            State = reducer(State, action);
            StateChanged?.Invoke(State);
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            return source.Subscribe(observer);
        }
    }
}
