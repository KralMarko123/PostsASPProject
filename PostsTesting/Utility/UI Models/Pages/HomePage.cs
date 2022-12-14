using FluentAssertions;
using Microsoft.Playwright;
using PostsTesting.Utility.Pages;

namespace PostsTesting.Utility.UI_Models.Pages
{
    public class HomePage : Page
    {
        private static string url => $"{baseUrl}/";
        public readonly Modal modal;

        public HomePage(IPage page) : base(page)
        {
            modal = new Modal(page);
        }

        public ILocator home => page.Locator(".home");
        public ILocator username => page.Locator(".nav__username");
        public ILocator postCard => page.Locator(".post");
        public ILocator postList => page.Locator(".posts__list");
        public ILocator createPost => page.Locator(".action__item", new PageLocatorOptions { HasTextString = "Create Post" });
        public ILocator infoMessage => page.Locator(".info__message");
        public ILocator dropdownMenu => page.Locator(".nav__actions");
        public ILocator myPostsCheckbox => page.Locator("#showOnlyMyPosts");
        public ILocator hiddenPostsCheckbox => page.Locator("#showHiddenPosts");

        public async Task Visit()
        {
            await page.GotoAsync(url);
        }

        public async Task HoverDropdownMenu()
        {
            await dropdownMenu.HoverAsync();
            await dropdownMenu.WaitForAsync();
        }

        public async Task ToggleMyPostsCheckbox(bool shouldBeChecked = true)
        {
            if (shouldBeChecked) await myPostsCheckbox.CheckAsync();
            else await myPostsCheckbox.UncheckAsync();
        }

        public async Task ToggleHiddenPostsCheckbox(bool shouldBeChecked = true)
        {
            if (shouldBeChecked) await hiddenPostsCheckbox.CheckAsync();
            else await hiddenPostsCheckbox.UncheckAsync();
        }

        public async Task ClickCreatePostButton()
        {
            await HoverDropdownMenu();
            await createPost.ClickAsync();
        }

        public async Task CheckDefaultState()
        {
            await title.WaitForAsync();
            var homeElementsAreDisplayed = await title.IsVisibleAsync() && await description.IsVisibleAsync();
            homeElementsAreDisplayed.Should().BeTrue();

            await ClickCreatePostButton();
            await modal.CheckVisibility("Create A Post");
            await modal.CloseModal();

            var postsArePresent = await WaitForPostsToLoad();
            if (postsArePresent)
            {
                var postCount = await GetNumberOfPosts();
                for (int i = 0; i < postCount; i++)
                {
                    var post = new Post(page, postCard.Nth(i));
                    await post.CheckPostState();
                }
            }
            else
            {
                var infoMessageIsDisplyed = await infoMessage.IsVisibleAsync();
                var infoMessageText = await infoMessage.TextContentAsync();

                infoMessageIsDisplyed.Should().BeTrue();
                infoMessageText.Should().Be("Seems there are no posts.");
            }
        }

        public async Task<bool> WaitForPostsToLoad()
        {
            await postList.WaitForAsync();
            var postsAreVisible = await postList.IsVisibleAsync();
            return postsAreVisible;
        }

        public Post GetPostWithTitle(string titleToFindBy)
        {
            var newlyCreatedPostCard = page.Locator(".post", new PageLocatorOptions { HasTextString = titleToFindBy });
            var newlyCreatedPost = new Post(page, newlyCreatedPostCard);

            return newlyCreatedPost;
        }

        public async Task<int> GetNumberOfPosts()
        {
            var numberOfPosts = await postCard.CountAsync();
            return numberOfPosts;
        }
    }
}
