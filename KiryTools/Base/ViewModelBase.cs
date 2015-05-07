using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using KiryTools.Other;

namespace KiryTools.Base
{
    /// <summary>
    /// This is a base clase to all ViewModels.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Provide access to params.
        /// </summary>
        public Parametrizer Params { get { return Parametrizer.ParametrizerInstance; } }
        /// <summary>
        /// This event notify when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// This method notify when a property has changed.
        /// </summary>
        /// <param name="name">Property name.</param>
        private void NotifyChanges(string name)
        {
            if (PropertyChanged == null || name == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        protected void NotifyChanges(object property)
        {
            var propertyInfo = GetType().GetProperties()
                .FirstOrDefault(t => t.GetValue(this).Equals(property));
            if(propertyInfo==null)return;
            NotifyChanges(propertyInfo.Name);
        }
        /// <summary>
        /// Este método agrega un valor a el contenedor y notifica a la interfaz 
        /// que ha cambiado la propiedad.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container">contenedor de valores</param>
        /// <param name="newValue">Nuevo valor que se asignara al contenedor</param>
        /// <param name="name">Nombre de la propiedad toma el nombre del miembro que lo llama.</param>
        protected void SetProperty<T>(ref T container, T newValue, [CallerMemberName]string name = "")
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (null == newValue) return;
            container = newValue;
            NotifyChanges(name);
        }

        private InformationKind _information;
        /// <summary>
        /// Información que se mostrara al usuario.
        /// </summary>
        public InformationKind Information
        {
            get
            {
                return _information;
            }
            set
            {
                SetProperty(ref _information, value);
            }
        }

        private bool _loading;
        /// <summary>
        /// Se muestra al usuario que se esta cargando la data.
        /// </summary>
        public bool Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                SetProperty(ref _loading, value);
            }
        }

    }
}
