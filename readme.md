# FacebookSharp: A .NET library for Facebook Graph API.
[![NuGet](https://img.shields.io/nuget/v/CMS365.FacebookSharp.svg?maxAge=3600)](https://www.nuget.org/packages/CMS365.FacebookSharp/)

FacebookSharp is a .NET library that enables you to authenticate and make graph API calls to Facebook. It's used for posting feeds and contents on Facebook using C# and .NET
# Installation
FacebookSharp is [available on NuGet](https://www.nuget.org/packages/CMS365.FacebookSharp/). Use the package manager
console in Visual Studio to install it:

```pwsh
Install-Package CMS365.FacebookSharp
```
# API support

| FacebookSharp version | Facebook Graph API version | Build versions
| -------------------- | ------------------- |----------------------- |
| 6                    | 17                  | x                      |

FacebookSharp currently supports the following Facebook Graph APIs:

-   Getting started
    -   [Creating an app](#creating-an-app)
-   Access & Security
    -   [Getting the access token](#authorization-and-authentication).
-   Using the FacebookSharp
    -   [Using the FacebookSharp](#using-the-facebookSharp).

## Creating an App

Please visit https://developers.facebook.com/apps and create an app.

## Authorization and authentication

Please visit https://developers.facebook.com/tools/explorer/ and generate a user token.

[![Generate a user token](https://i.imgur.com/a2WvGaH.png)](https://developers.facebook.com/tools/explorer/)

You can adjust permissions based on your needs. This is a short lived token and can be used for Facebook Graph api for user level operations. We will use it to generate a long live user token.

User postman and send a request to the following endpoint and get a long lived user token.

```C#
https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id=APP_CLIENT_ID&client_secret=APP_CLIENT_SECRET&fb_exchange_token=YOUR_SHORT_LIVED_USER_TOKEN_HERE
```
You will get a response like 
```C#
{
    "access_token": "vMF7UXNvRZC6m58zr0tRQJP3MVCZBd6JDhHkyCXjWcfag8hfcmjImn85B2YPZAUYK4eirj9ZA0ZAsp1TocZD",
    "token_type": "bearer",
    "expires_in": 5182228
}
```
We will get an access_token which is long lived user token and can be used for Facebook Graph api for user level operations but we have to generate a page token so that we can perform action on a Facebook page.
```C#
https://graph.facebook.com/FACEBOOK_PAGE_ID?fields=access_token&access_token=LONG_LIVED_USER_TOKEN
```

```C#
{
    "access_token": "EAASZAbmgGb7YBAFWM3uNUKan1ZBTf4rIAQiLzPSNMa7Lm3Ak1R8tNAVwsORl0LZAcPNEURzFgl6",
    "id": "111444904022049"
}
```
We have now got a page token which we will use to perform actions on a Facebook page.

## Using the FacebookSharp
 Initialize the instance with the page token
```C#
var facebookController = new FacebookSharp.FacebookController("EAASZAbmgGb7YBAFWM3uNUKan1ZBTf4rIAQiLzPSNMa7Lm3Ak1R8tNAVwsORl0LZAcPNEURzFgl6");
```

## Page
### Get page details
```C#
var pageDetail = await facebookController.GetPageDetailsAsync("[PAGE_ID]");
```
You can also pass page fields you want to get, list of fields applicable to a page is available at https://developers.facebook.com/docs/graph-api/reference/page/
```C#
var pageDetail = await facebookController.GetPageDetailsAsync("[PAGE_ID]","name,about,link,cover");
```
### Post with multiline text and images
```C#
var postDetails = await facebookController.PostFeedAsync("[PAGE_ID]", new FacebookSharp.Entities.PageFeedRequestContent()
{
    MessageLines = new List<string>() { "Loose Mineral Foundation Shade", "https://google.com","$20" },
    PhotoUrls= new List<string>() { "https://cdn.pixabay.com/photo/2017/09/01/00/15/png-2702691_640.png" }
});
```
## General Graph API methods
You can call direct graph API method If there is no mapping available. For example
### Get
```C#
var pageInfo = await facebookController.Get("/[apge_id]?fields=name,about,link,cover");
```


