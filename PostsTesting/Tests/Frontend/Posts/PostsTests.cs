﻿using PostsTesting.Tests.Frontend.Base;
using Xunit;

namespace PostsTesting.Tests.Frontend.Posts
{
    public class PostsTests : PostsUiTestBase
    {
        [Fact]
        public async Task VerifyPostDetailsPageIsDisplayedCorrectlyForEachPost()
        {
            await VerifyPostDetailsForEachPost();
        }

        [Fact]
        public async Task VerifyPostDetailsPageForNonExistentPost()
        {
            await VerifyPostDetailsForNotFoundPost();
        }

        [Fact]
        public async Task VerifyNewlyCreatedPostIsPresentOnHomePage()
        {
            await VerifyPostCanBeCreated();
        }

        [Fact]
        public async Task VerifyPostCanBeEditedFromTheHomepage()
        {
            await VerifyPostCanBeUpdated();
        }

        [Fact]
        public async Task VerifyPostIsNotPresentAfterBeingDeleted()
        {
            await VerifyPostCanBeDeleted();
        }
    }
}
