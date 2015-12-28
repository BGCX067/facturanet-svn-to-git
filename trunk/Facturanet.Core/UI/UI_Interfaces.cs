using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Reflection;


namespace Facturanet.UI
{
    /// <summary>
    /// Object with facilities to the User Interfase
    /// </summary>
    public interface IUIObject
    {
    }

    /// <summary>
    /// Object with facilities to be edited in the User Interfase
    /// </summary>
    public interface IEditableUIObject : 
        IUIObject, 
        IDiscartableChanges,
        INotifyPropertyChanged, 
        INotifyPropertyChanging,
        IEditableObject
    {
        bool IsNew();
        int Version { get; }
    }

    public interface IDeletableUIObject : IUIObject
    {
        Guid Id { get; }
        bool IsDeleted();
        void MarkAsDelete();
    }

    /// <summary>
    /// Supports the implementation of requiered interfaces.
    /// </summary>
    internal interface IEditableUIObjectSupporter :
        IBackupable,
        IDiscartableChanges,
        INotifyPropertyChanging,
        INotifyPropertyChanged,
        IEditableObject
    {
        void SetSupportedObject(object supportedObject);
        /// <summary>
        /// Gets the value of a property. If the property is not defined returns the default value of the type.
        /// </summary>
        T GetData<T>(string propertyName);

        /// <summary>
        /// Sets the value of a property. If the property exists override the previous value.
        /// </summary>
        /// <remarks>
        /// Raises PropertyChangingEvent, PropertyChangedEvent and if DiscartableChangesControl is 
        /// enabled mantains a backup.
        /// </remarks>
        void SetData<T>(string propertyName, T value);
    }

    /// <summary>
    /// Object that can be backuped and restored.
    /// </summary>
    public interface IBackupable
    {
        /// <summary>
        /// Returns a object with the backup of current data.
        /// </summary>
        object Backup();

        /// <summary>
        /// Replace current data with the backup data.
        /// </summary>
        void Restore(object backupData);

        /// <summary>
        /// Returns the diferences between current and backupData.
        /// </summary>
        ValueChangedDescriptorCollection GetDifferences(object backupData);
    }

    /// <summary>
    /// Object that can restores this original values.
    /// </summary>
    public interface IDiscartableChanges
    {
        /// <summary>
        /// Gets or sets a value indicating whether the object allow discard changes manually.
        /// </summary>
        bool DiscartableChangesControl { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has changes.
        /// </summary>
        /// <remarks>
        /// To use this, DiscartableChangesControl has to be true.
        /// </remarks>
        bool IsDirty();

        bool IsDirty(bool byValues);

        /// <summary>
        /// Discards the changes.
        /// </summary>
        /// <remarks>
        /// To use this, DiscartableChangesControl has to be true.
        /// </remarks>
        ValueChangedDescriptorCollection GetChanges();

        /// <summary>
        /// Accepts the changes.
        /// </summary>
        /// <remarks>
        /// To use this, DiscartableChangesControl has to be true.
        /// </remarks>
        void DiscardChanges();


        /// <summary>
        /// Reverts the value of a property
        /// </summary>
        void RevertPropertyValue(string property);

        /// <summary>
        /// Gets the changes respect the original version.
        /// </summary>
        /// <remarks>
        /// To use this, DiscartableChangesControl has to be true.
        /// </remarks>
        void AcceptChanges();
    }
}
