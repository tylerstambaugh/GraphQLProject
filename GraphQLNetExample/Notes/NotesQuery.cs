using GraphQL.Types;
using GraphQLNetExample.Data;

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

            Field<ListGraphType<NoteType>>("notesFromEF", resolve: context =>
            {
                var notesContext = context.RequestServices.GetRequiredService<NotesContext>();
                return notesContext.Notes.ToList();
            });
        }
    }
}