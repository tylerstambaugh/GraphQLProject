using GraphQL.Types;

namespace GraphQLNetExample.Notes
{
    public class NoteType : ObjectGraphType<Note>
    {
        public NoteType()
        {
            nameof = "Note";
            Description = "Note Type";
        }
    }
}