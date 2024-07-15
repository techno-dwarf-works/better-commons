using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class AnimatorControllerExtensions
    {
        #region Get Parameters

        public static string[] GetAllIntegerNames(this AnimatorController animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Int);
        }

        public static string[] GetAllFloatNames(this AnimatorController animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Float);
        }

        public static string[] GetAllBoolNames(this AnimatorController animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Bool);
        }

        private static string[] GetAllTriggerNames(this AnimatorController animator)
        {
            return animator.GetParameterNamesOfType(AnimatorControllerParameterType.Trigger);
        }

        public static string[] GetParameterNamesOfType(this AnimatorController animator, AnimatorControllerParameterType parameterType)
        {
            return animator.GetParametersOfType(parameterType)
                .Select(p => p.name)
                .ToArray();
        }

        #endregion

        #region Has Parameters

        public static bool HasParameter(this AnimatorController animator, string name)
        {
            var names = animator.parameters.Select(p => p.name);
            return names.Contains(name);
        }

        public static bool HasInteger(this AnimatorController animator, string name)
        {
            return animator.GetAllIntegerNames().Contains(name);
        }

        public static bool HasFloat(this AnimatorController animator, string name)
        {
            return animator.GetAllFloatNames().Contains(name);
        }

        public static bool HasBool(this AnimatorController animator, string name)
        {
            return animator.GetAllBoolNames().Contains(name);
        }

        public static bool HasTrigger(this AnimatorController animator, string name)
        {
            return animator.GetAllTriggerNames().Contains(name);
        }

        #endregion

        private static AnimatorControllerParameter[] GetParametersOfType(this AnimatorController animator, AnimatorControllerParameterType parameterType)
        {
            return animator.parameters
                .Where(p => p.type == parameterType)
                .ToArray();
        }
    }
}