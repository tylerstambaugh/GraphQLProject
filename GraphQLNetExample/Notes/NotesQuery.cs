using GraphQL.Types;

namespace GraphQLNetExample.Notes
{
    public class NotesQuery : ObjectGraphType
    {
        public NotesQuery()
        {
            Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note>
            {
                new Note { Id = Guid.NewGuid(), Message = "This is the first note buster" },
                new Note { Id = Guid.NewGuid(), Message = "This is the second note big fella" },

            });
        }
    }
}