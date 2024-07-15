using System.Linq;
using UnityEditor.Animations;
using UnityEngine;

namespace Better.Commons.EditorAddons.Extensions
{
    public static class AnimatorControllerExtensions
    {
        #region Get Parameters

        public static string[] GetAllIntegerNames(this AnimatorController self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Int);
        }

        public static string[] GetAllFloatNames(this AnimatorController self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Float);
        }

        public static string[] GetAllBoolNames(this AnimatorController self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Bool);
        }

        public static string[] GetAllTriggerNames(this AnimatorController self)
        {
            return self.GetParameterNamesOfType(AnimatorControllerParameterType.Trigger);
        }

        public static string[] GetParameterNamesOfType(this AnimatorController self, AnimatorControllerParameterType parameterType)
        {
            return self.GetParametersOfType(parameterType)
                .Select(p => p.name)
                .ToArray();
        }

        #endregion

        #region Has Parameters

        public static bool HasParameter(this AnimatorController self, string name)
        {
            var names = self.parameters.Select(p => p.name);
            return names.Contains(name);
        }

        public static bool HasInteger(this AnimatorController self, string name)
        {
            return self.GetAllIntegerNames().Contains(name);
        }

        public static bool HasFloat(this AnimatorController self, string name)
        {
            return self.GetAllFloatNames().Contains(name);
        }

        public static bool HasBool(this AnimatorController self, string name)
        {
            return self.GetAllBoolNames().Contains(name);
        }

        public static bool HasTrigger(this AnimatorController self, string name)
        {
            return self.GetAllTriggerNames().Contains(name);
        }

        #endregion

        private static AnimatorControllerParameter[] GetParametersOfType(this AnimatorController self, AnimatorControllerParameterType parameterType)
        {
            return self.parameters
                .Where(p => p.type == parameterType)
                .ToArray();
        }
    }
}