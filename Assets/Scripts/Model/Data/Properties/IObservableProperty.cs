namespace DEEPP.Model.Data.Properties
{
    public interface IObservableProperty<TPropertyType>
    {
        public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);
        public event OnPropertyChanged OnChanged;
        public TPropertyType Value { get; set; }
    }
}