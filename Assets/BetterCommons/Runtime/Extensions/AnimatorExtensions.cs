using System.Linq;
using UnityEngine;
using Parameter = UnityEngine.AnimatorControllerParameter;
using ParameterType = UnityEngine.AnimatorControllerParameterType;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class AnimatorExtensions
    {
        #region Get Parameters

        public static string[] GetAllIntegerNames(this Animator animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Int);
        }

        public static string[] GetAllFloatNames(this Animator animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Float);
        }

        public static string[] GetAllBoolNames(this Animator animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Bool);
        }

        private static string[] GetAllTriggerNames(this Animator animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Trigger);
        }

        public static string[] GetParameterNamesOfType(this Animator animator, ParameterType parameterType)
        {
            return animator.GetParametersOfType(parameterType)
                .Select(p => p.name)
                .ToArray();
        }

        #endregion

        #region Has Parameters

        public static bool HasParameter(this Animator animator, string name)
        {
            var names = animator.parameters.Select(p => p.name);
            return names.Contains(name);
        }

        public static bool HasInteger(this Animator animator, string name)
        {
            return animator.GetAllIntegerNames().Contains(name);
        }

        public static bool HasFloat(this Animator animator, string name)
        {
            return animator.GetAllFloatNames().Contains(name);
        }

        public static bool HasBool(this Animator animator, string name)
        {
            return animator.GetAllBoolNames().Contains(name);
        }

        public static bool HasTrigger(this Animator animator, string name)
        {
            return animator.GetAllTriggerNames().Contains(name);
        }

        #endregion

        #region Set Parameters

        public static void ResetAllTriggers(this Animator animator)
        {
            var names = animator.GetAllTriggerNames();

            for (var i = 0; i < names.Length; i++)
            {
                animator.ResetTrigger(names[i]);
            }
        }

        public static void SetAllBools(this Animator animator, bool value)
        {
            var names = animator.GetAllBoolNames();
            for (var i = 0; i < names.Length; i++)
            {
                animator.SetBool(names[i], value);
            }
        }

        public static void SetAllIntegers(this Animator animator, int value)
        {
            var names = animator.GetAllIntegerNames();
            for (var i = 0; i < names.Length; i++)
            {
                animator.SetInteger(names[i], value);
            }
        }

        public static void SetAllFloats(this Animator animator, float value)
        {
            var names = animator.GetAllFloatNames();
            for (var i = 0; i < names.Length; i++)
            {
                animator.SetFloat(names[i], value);
            }
        }

        #endregion

        private static Parameter[] GetParametersOfType(this Animator animator, ParameterType parameterType)
        {
            return animator.parameters
                .Where(p => p.type == parameterType)
                .ToArray();
        }
    }
}