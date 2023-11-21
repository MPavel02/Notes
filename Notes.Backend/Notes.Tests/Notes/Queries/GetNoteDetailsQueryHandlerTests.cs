﻿using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Persistence;
using Notes.Tests.Common;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Notes.Application.Notes.Queries.GetNoteDetails;
using System;
using Shouldly;

namespace Notes.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetNoteDetailsQuery
            {
                UserId = NotesContextFactory.UserBId,
                Id = Guid.Parse("9A83A371-65F8-4951-8258-863E5E7DBD56")
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
