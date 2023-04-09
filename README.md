# Blazor Server-Side + ApiController

This example shows you how to use the [Okta ASP.NET Core SDK] to sign in a user in your Blazor Server-Side applications. The user's browser is first redirected to the Okta-hosted sign-in page. After the user authenticates, they are redirected back to your application. ASP.NET Core automatically populates `HttpContext.User` with the information Okta sends back about the user.

## Running This Example

### Clone this repository

```git clone https://github.com/ivpavl/SmrtNutrition.git```

Navigate to the folder where the project file is located and type the following:

```dotnet run```

### Change appsettings if needed

Replace what ever you need in the `appsettings.json`

