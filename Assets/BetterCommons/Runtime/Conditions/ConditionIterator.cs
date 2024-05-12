using System;
using System.Collections.Generic;
using Better.Commons.Runtime.Extensions;
using Better.Commons.Runtime.Utility;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class ConditionIterator<TCondition> where TCondition : Condition
    {
        [SerializeReference] private List<TCondition> _sourceSet;
        [SerializeField] private bool _safe;
        [SerializeField] private bool _logExceptions;

        private HashSet<TCondition> _currentSet;

        public ConditionIterator(bool safe, bool logExceptions)
        {
            _safe = safe;
            _logExceptions = logExceptions;
            _sourceSet = new List<TCondition>();
        }

        public ConditionIterator() : this(false, Condition.DefaultLogException)
        {
        }

        public virtual void Rebuild()
        {
            _currentSet ??= new HashSet<TCondition>();
            _currentSet.Clear();
            _currentSet.CollectByValidation(_sourceSet, _logExceptions);
            _currentSet.Rebuild();
        }

        public void Add(TCondition condition)
        {
            if (condition == null)
            {
                if (_logExceptions)
                {
                    DebugUtility.LogException<ArgumentNullException>(nameof(condition));
                }

                return;
            }

            if (Has(condition))
            {
                if (_logExceptions)
                {
                    var message = $"{nameof(condition)}({condition}) already added";
                    DebugUtility.LogException<ArgumentException>(message);
                }

                return;
            }

            _sourceSet.Add(condition);
            OnAdded(condition);
        }

        protected virtual void OnAdded(TCondition condition)
        {
        }

        public void Add(IEnumerable<TCondition> conditions)
        {
            if (conditions == null)
            {
                if (_logExceptions)
                {
                    DebugUtility.LogException<ArgumentNullException>(nameof(conditions));
                }

                return;
            }

            foreach (var condition in conditions)
            {
                Add(condition);
            }
        }

        private bool Has(TCondition condition)
        {
            if (_sourceSet == null)
            {
                return false;
            }

            return _sourceSet.Contains(condition);
        }

        public bool HasAll(IEnumerable<TCondition> conditions)
        {
            if (conditions == null)
            {
                if (_logExceptions)
                {
                    DebugUtility.LogException<ArgumentNullException>(nameof(conditions));
                }

                return false;
            }

            foreach (var condition in conditions)
            {
                if (!Has(condition))
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasAny(IEnumerable<TCondition> conditions)
        {
            if (conditions == null)
            {
                if (_logExceptions)
                {
                    DebugUtility.LogException<ArgumentNullException>(nameof(conditions));
                }

                return false;
            }

            foreach (var condition in conditions)
            {
                if (Has(condition))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(TCondition condition)
        {
            var removed = _sourceSet.Remove(condition);
            if (removed)
            {
                OnRemoved(condition);
            }

            return removed;
        }

        protected virtual void OnRemoved(TCondition condition)
        {
        }

        public void Remove(IEnumerable<TCondition> conditions)
        {
            if (conditions == null)
            {
                if (_logExceptions)
                {
                    DebugUtility.LogException<ArgumentNullException>(nameof(conditions));
                }

                return;
            }

            _sourceSet.RemoveRange(conditions);
        }

        public virtual bool IterateAll()
        {
            if (_currentSet == null)
            {
                return false;
            }

            if (_safe)
            {
                return _currentSet.SafeInvokeAll(_logExceptions);
            }

            return _currentSet.InvokeAll();
        }

        public virtual bool IterateAny()
        {
            if (_currentSet == null)
            {
                return false;
            }

            if (_safe)
            {
                return _currentSet.SafeInvokeAny(_logExceptions);
            }

            return _currentSet.InvokeAny();
        }
    }

    [Serializable]
    public class ConditionIterator : ConditionIterator<Condition>
    {
        public ConditionIterator(bool safe, bool logExceptions) : base(safe, logExceptions)
        {
        }

        public ConditionIterator() : this(false, Condition.DefaultLogException)
        {
        }
    }
}