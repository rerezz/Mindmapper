[global::System.Serializable]
public class SyntaxException : System.Exception
{

    public SyntaxException() { }
    public SyntaxException(string message) : base(message) { }
    public SyntaxException(string message, System.Exception inner) : base(message, inner) { }
    protected SyntaxException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
}