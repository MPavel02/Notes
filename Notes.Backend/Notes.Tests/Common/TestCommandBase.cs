using Notes.Persistence;
using System;

namespace Notes.Tests.Common
{
    public abstract class TestCommandBase
        : IDisposable
    {
        public readonly NotesDbContext Context;

        public TestCommandBase()
        {
            Context = NotesContextFactory.Create();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
}
