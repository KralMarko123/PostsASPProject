using FluentAssertions;
using Microsoft.Playwright;
using PostsTesting.Utility.Pages;
using PostsTesting.Utility.UI_Models.Components;

namespace PostsTesting.Utility.UI_Models.Pages
{
    public class PostDetailsPage : Page
    {
        private static string url => $"{baseUrl}/posts";
        public readonly Modal modal;
        public readonly Select select;

        public PostDetailsPage(IPage page) : base(page)
        {
            modal = new Modal(page);
            select = new Select(page);
        }

        public ILocator toggleUsersButton => page.Locator(".footer__action", new PageLocatorOptions { HasText = "Toggle Users" });

        public async Task Visit(string postId)
        {
            await page.GotoAsync($"{url}/{postId}");
        }

        public async Task ClickOnToggleUsersButton()
        {
            await toggleUsersButton.ClickAsync();
        }

        public async Task ClickOnBackButton()
        {
            await back.ClickAsync();
        }

        public async Task CheckPostDetails(string expectedTitle, string expectedContent)
        {
            await title.WaitForAsync();

            var detailsElementsAreDisplayed = await title.IsVisibleAsync() && await description.IsVisibleAsync();
            var titleText = await title.TextContentAsync();
            var descriptionText = await description.TextContentAsync();

            detailsElementsAreDisplayed.Should().BeTrue();

            titleText.Should().Be(expectedTitle);
            descriptionText.Should().Be(expectedContent);
        }
    }
}
