using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GF.Mvvm
{
    public class PropertyChangeObservable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region - Methoden oeffentlich -

        private static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            return GetPropertyNameFast(expression);
        }

        #endregion

        #region - Methoden privat -

        private static string GetPropertyNameFast(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("MemberExpression is expected in expression.Body", "expression");
            }

            const string vblocalPrefix = "$VB$Local_";
            var member = memberExpression.Member;
            if (
                member.MemberType == MemberTypes.Field &&
                member.Name != null &&
                member.Name.StartsWith(vblocalPrefix))
            {
                return member.Name.Substring(vblocalPrefix.Length);
            }

            return member.Name;
        }

        #endregion

        #region - Methoden privat -

        protected bool SetField<T>(ref T field, T value, string propertyName, Action changedCallback)
        {
            if (this.AreEqual(ref field, value))
            {
                return false;
            }

            // ReSharper disable once ExplicitCallerInfoArgument
            this.RaisePropertyChanging(propertyName);
            field = value;

            // ReSharper disable once ExplicitCallerInfoArgument
            this.RaisePropertyChanged(propertyName);

            if (changedCallback != null)
            {
                changedCallback();
            }

            return true;
        }

        protected bool SetField<T>(ref T field, T value, Expression<Func<T>> expression, Action changedCallback)
        {
            return this.SetField(ref field, value, GetPropertyName(expression), changedCallback);
        }

        protected bool SetField<T>(ref T field, T value, Expression<Func<T>> expression)
        {
            return this.SetField(ref field, value, expression, null);
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            return this.SetField(ref field, value, propertyName, null);
        }

        protected bool AreEqual<T>(ref T field, T value)
        {
            return EqualityComparer<T>.Default.Equals(field, value);
        }

        protected bool AreEqual<T>(ref T field, T value, IEqualityComparer<T> comparer)
        {
            return comparer.Equals(field, value);
        }

        protected void RaisePropertyChanging([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanging;
            if (handler != null)
            {
                handler(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        protected void RaisePropertiesChanging(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                this.RaisePropertyChanging(string.Empty);
                return;
            }

            foreach (var propertyName in propertyNames)
            {
                this.RaisePropertyChanging(propertyName);
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertiesChanged(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                this.RaisePropertyChanged(string.Empty);
                return;
            }

            foreach (var propertyName in propertyNames)
            {
                this.RaisePropertyChanged(propertyName);
            }
        }

        #endregion
    }
}