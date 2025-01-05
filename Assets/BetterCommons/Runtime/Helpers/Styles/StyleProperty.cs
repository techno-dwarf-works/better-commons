namespace Better.Commons.Runtime.Helpers.Styles
{
    public struct StyleProperty<T>
    {
        private T _value;
        public bool HasValue { get; private set; }

        public T Value
        {
            get => _value;
            set
            {
                HasValue = true;
                _value = value;
            }
        }
    }
}