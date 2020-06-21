namespace GqlService
{
    public class ReferenceValueChange
    {
        public static string Topic => nameof(ReferenceValueChange);

        public string Name { get; set; }

        public object Value { get; set; }

        public ReferenceValueChange() {}

        public ReferenceValueChange(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}