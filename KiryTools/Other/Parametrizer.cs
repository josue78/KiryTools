using System.Collections.Generic;
using KiryTools.Base;

namespace KiryTools.Other
{
    /// <summary>
    /// This is the way to exchange params betwen pages
    /// </summary>
    public class Parametrizer
    {
        public readonly static Parametrizer ParametrizerInstance = new Parametrizer();

        private Parametrizer()
        {

        }
        /// <summary>
        /// Params thats are stored
        /// </summary>
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();
        public T GetParam<T>() where T : ViewModelBase
        {
            object value;
            _values.TryGetValue(typeof(T).Name, out value);
            return value as T;
        }
        /// <summary>
        /// Add or update a value to params 
        /// </summary>
        /// <typeparam name="T">ViewModelBase that send this param</typeparam>
        /// <param name="viewModel">ViewModel that send this param</param>
        /// <param name="param">Object that will be stored</param>
        public void SetParam<T>(T viewModel, object param) where T : ViewModelBase
        {
            _values[viewModel.GetType().Name] = param;
        }
        /// <summary>
        /// Remove all params that are stored
        /// </summary>
        public void RemoveAll()
        {
            _values.Clear();
        }
    }
}
