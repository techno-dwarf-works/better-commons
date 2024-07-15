using System.Linq;
using UnityEngine;
using Parameter = UnityEngine.AnimatorControllerParameter;
using ParameterType = UnityEngine.AnimatorControllerParameterType;

namespace Better.Commons.Runtime.Extensions
{
    public static class AnimatorExtensions
    {
        #region Get Parameters

        public static string[] GetAllIntegerNames(this Animator self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Int);
        }

        public static string[] GetAllFloatNames(this Animator self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Float);
        }

        public static string[] GetAllBoolNames(this Animator self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Bool);
        }

        public static string[] GetAllTriggerNames(this Animator self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Trigger);
        }

        public static string[] GetParameterNamesOfType(this Animator self, ParameterType parameterType)
        {
            return self.GetParametersOfType(parameterType)
                .Select(p => p.name)
                .ToArray();
        }

        #endregion

        #region Has Parameters

        public static bool HasParameter(this Animator self, string name)
        {
            var names = self.parameters.Select(p => p.name);
            return names.Contains(name);
        }

        public static bool HasInteger(this Animator self, string name)
        {
            return self.GetAllIntegerNames().Contains(name);
        }

        public static bool HasFloat(this Animator self, string name)
        {
            return self.GetAllFloatNames().Contains(name);
        }

        public static bool HasBool(this Animator self, string name)
        {
            return self.GetAllBoolNames().Contains(name);
        }

        public static bool HasTrigger(this Animator self, string name)
        {
            return self.GetAllTriggerNames().Contains(name);
        }

        #endregion

        #region Set Parameters

        public static void ResetAllTriggers(this Animator self)
        {
            var names = self.GetAllTriggerNames();

            for (var i = 0; i < names.Length; i++)
            {
                self.ResetTrigger(names[i]);
            }
        }

        public static void SetAllBools(this Animator self, bool value)
        {
            var names = self.GetAllBoolNames();
            for (var i = 0; i < names.Length; i++)
            {
                self.SetBool(names[i], value);
            }
        }

        public static void SetAllIntegers(this Animator self, int value)
        {
            var names = self.GetAllIntegerNames();
            for (var i = 0; i < names.Length; i++)
            {
                self.SetInteger(names[i], value);
            }
        }

        public static void SetAllFloats(this Animator self, float value)
        {
            var names = self.GetAllFloatNames();
            for (var i = 0; i < names.Length; i++)
            {
                self.SetFloat(names[i], value);
            }
        }

        #endregion

        private static Parameter[] GetParametersOfType(this Animator self, ParameterType parameterType)
        {
            return self.parameters
                .Where(p => p.type == parameterType)
                .ToArray();
        }
    }
}