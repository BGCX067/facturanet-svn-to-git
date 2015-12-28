using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Facturanet.Util;

namespace Facturanet.UI
{
    public class FacturanetBindingList<T> : BindingList<T>
    {
        private List<T> deletedItems;
        private bool typeIsUIObject;
        private bool typeIsEditable;
        private bool typeIsDeletable;

        /// <summary>
        /// Returns the deleted items in the FacturanetBindingList
        /// </summary>
        public IEnumerable<T> GetDeletedItems()
        {
            return deletedItems.AsEnumerable();
        }

        /// <summary>
        /// Returns the updated items in the FacturanetBindingList
        /// </summary>
        public IEnumerable<T> GetUpdatedItems()
        {
            if (typeIsEditable)
                foreach (UI.IEditableUIObject item in this)
                {
                    if (!item.IsNew() && item.IsDirty())
                        yield return (T)item;
                }
            else
                throw new NotSupportedException("T don't implement UI.IDiscartableChanges.");
        }

        /// <summary>
        /// Returns the inserted items in the FacturanetBindingList
        /// </summary>
        public IEnumerable<T> GetInsertedItems()
        {
            if (typeIsEditable)
                foreach (UI.IEditableUIObject item in this)
                {
                    if (item.IsNew())
                        yield return (T)item;
                }
            else
                throw new NotSupportedException("T don't implement UI.ICreableUIObject.");
        }

        public FacturanetBindingList(IList<T> list)
            : base()
        {
            Type type = typeof(T);
            typeIsUIObject = type.ImplementsInterface<UI.IUIObject>();
            typeIsEditable = type.ImplementsInterface<UI.IEditableUIObject>();
            typeIsDeletable = type.ImplementsInterface<UI.IDeletableUIObject>();
            if (typeIsUIObject)
            {
                AllowEdit = typeIsEditable;
                AllowRemove = typeIsDeletable;
                AllowNew = AllowRemove;
            }

            if (list != null)
                foreach (var item in list)
                    Add(item);

            deletedItems = new List<T>();
        }

        protected override void InsertItem(int index, T item)
        {
            if (typeIsEditable)
                (item as UI.IDiscartableChanges).DiscartableChangesControl = true;
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                var item = this[index];

                if (typeIsDeletable)
                {
                    UI.IDeletableUIObject deletable = item as UI.IDeletableUIObject;
                    deletable.MarkAsDelete();
                }

                if (!typeIsEditable || !(item as IEditableUIObject).IsNew())
                    deletedItems.Add(item);

                base.RemoveItem(index);
            }
        }

        #region Sorting //From http://code.google.com/p/banshee32/trunk/banshee32/Control/SearchableSortableBindingList.cs

        private bool isSorted;
        private PropertyDescriptor sortProperty;
        private ListSortDirection sortDirection;

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        // Missing from Part 2
        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirection; }
        }

        // Missing from Part 2
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortProperty; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            // Get list to sort
            // Note: this.Items is a non-sortable ICollection<T>
            List<T> items = this.Items as List<T>;

            // Apply and set the sort, if items to sort
            if (items != null)
            {
                PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
                
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }

            sortProperty = property;
            sortDirection = direction;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override bool IsSortedCore
        {
            get { return isSorted; }
        }

        protected override void RemoveSortCore()
        {
            //isSorted = false;
            //this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        #endregion

        #region Searching //From http://code.google.com/p/banshee32/trunk/banshee32/Control/SearchableSortableBindingList.cs

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            //TODO: Podría hacer algo como que si property es null busque en todos los campos
            //Todo: si solo quiero buscar por el comienzo?
            //Todo: el qkey tienq que ser texto si o si?


            // Specify search columns
            if (property == null) return -1;

            // Get list to search
            List<T> items = this.Items as List<T>;

            // Traverse list for value
            foreach (T item in items)
            {
                // Test column search value
                string value = (string)property.GetValue(item);

                // If value is the search value, return the 
                // index of the data item
                if ((string)key == value) return IndexOf(item);
            }
            return -1;
        }

        #endregion
    }
 }