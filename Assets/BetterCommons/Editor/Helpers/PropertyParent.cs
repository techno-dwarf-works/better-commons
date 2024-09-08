namespace Better.Commons.EditorAddons.Helpers
{
    public class PropertyParent
    {
        public object ParentInstance { get; }

        public string FieldName { get; }
        public int ElementIndex { get; }

        public PropertyParent(object parentInstance, string fieldName, int elementIndex)
        {
            ParentInstance = parentInstance;
            FieldName = fieldName;
            ElementIndex = elementIndex;
        }
    }
}