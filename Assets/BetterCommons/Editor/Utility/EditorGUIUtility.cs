using UnityEngine;

namespace Better.Commons.EditorAddons.Utility
{
    public static class EditorGUIUtility
    {
        public static int SelectionGrid(int selected, string[] texts, int xCount, GUIStyle style,
            params GUILayoutOption[] options)
        {
            var bufferSelected = selected;
            GUILayout.BeginVertical();
            var count = 0;
            var isHorizontal = false;

            for (var index = 0; index < texts.Length; index++)
            {
                var text = texts[index];

                if (count == 0)
                {
                    GUILayout.BeginHorizontal();
                    isHorizontal = true;
                }

                count++;
                if (GUILayout.Toggle(bufferSelected == index, text, new GUIStyle(style), options))
                    bufferSelected = index;

                if (count == xCount)
                {
                    GUILayout.EndHorizontal();
                    count = 0;
                    isHorizontal = false;
                }
            }

            if (isHorizontal) GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            return bufferSelected;
        }
    }
}