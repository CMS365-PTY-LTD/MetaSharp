using System.Text.Json.Serialization;

namespace MetaSharp.Entities.Page
{
    public class PageInfo
    {
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        [JsonPropertyName("business")]
        public Business Business { get; set; }

        [JsonPropertyName("can_checkin")]
        public bool CanCheckin { get; set; }

        [JsonPropertyName("can_post")]
        public bool CanPost { get; set; }

        [JsonPropertyName("checkins")]
        public int Checkins { get; set; }

        [JsonPropertyName("connected_instagram_account")]
        public ConnectedInstagramAccount ConnectedInstagramAccount { get; set; }

        [JsonPropertyName("connected_page_backed_instagram_account")]
        public ConnectedPageBackedInstagramAccount ConnectedPageBackedInstagramAccount { get; set; }

        [JsonPropertyName("cover")]
        public Cover Cover { get; set; }

        [JsonPropertyName("about")]
        public string About { get; set; }

        [JsonPropertyName("display_subtext")]
        public string DisplaySubtext { get; set; }

        [JsonPropertyName("displayed_message_response_time")]
        public string DisplayedMessageResponseTime { get; set; }

        [JsonPropertyName("emails")]
        public List<string> Emails { get; set; }

        [JsonPropertyName("fan_count")]
        public int FanCount { get; set; }

        [JsonPropertyName("followers_count")]
        public int FollowersCount { get; set; }

        [JsonPropertyName("global_brand_page_name")]
        public string GlobalBrandPageName { get; set; }

        [JsonPropertyName("has_transitioned_to_new_page_experience")]
        public bool HasTransitionedToNewPageExperience { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("category_list")]
        public List<CategoryList> CategoryList { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("instagram_business_account")]
        public InstagramBusinessAccount InstagramBusinessAccount { get; set; }

        [JsonPropertyName("is_always_open")]
        public bool IsAlwaysOpen { get; set; }

        [JsonPropertyName("is_community_page")]
        public bool IsCommunityPage { get; set; }

        [JsonPropertyName("is_eligible_for_branded_content")]
        public bool IsEligibleForBrandedContent { get; set; }

        [JsonPropertyName("is_messenger_bot_get_started_enabled")]
        public bool IsMessengerBotGetStartedEnabled { get; set; }

        [JsonPropertyName("is_messenger_platform_bot")]
        public bool IsMessengerPlatformBot { get; set; }

        [JsonPropertyName("is_owned")]
        public bool IsOwned { get; set; }

        [JsonPropertyName("is_permanently_closed")]
        public bool IsPermanentlyClosed { get; set; }

        [JsonPropertyName("is_published")]
        public bool IsPublished { get; set; }

        [JsonPropertyName("is_unclaimed")]
        public bool IsUnclaimed { get; set; }

        [JsonPropertyName("is_webhooks_subscribed")]
        public bool IsWebhooksSubscribed { get; set; }

        [JsonPropertyName("leadgen_tos_accepted")]
        public bool LeadgenTosAccepted { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("merchant_review_status")]
        public string MerchantReviewStatus { get; set; }

        [JsonPropertyName("messaging_feature_status")]
        public MessagingFeatureStatus MessagingFeatureStatus { get; set; }

        [JsonPropertyName("messenger_ads_default_icebreakers")]
        public List<string> MessengerAdsDefaultIcebreakers { get; set; }

        [JsonPropertyName("messenger_ads_quick_replies_type")]
        public string MessengerAdsQuickRepliesType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_with_location_descriptor")]
        public string NameWithLocationDescriptor { get; set; }

        [JsonPropertyName("page_token")]
        public string PageToken { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("place_type")]
        public string PlaceType { get; set; }

        [JsonPropertyName("promotion_eligible")]
        public bool PromotionEligible { get; set; }

        [JsonPropertyName("rating_count")]
        public int RatingCount { get; set; }

        [JsonPropertyName("single_line_address")]
        public string SingleLineAddress { get; set; }

        [JsonPropertyName("supports_donate_button_in_live_video")]
        public bool SupportsDonateButtonInLiveVideo { get; set; }

        [JsonPropertyName("talking_about_count")]
        public int TalkingAboutCount { get; set; }

        [JsonPropertyName("temporary_status")]
        public string TemporaryStatus { get; set; }

        [JsonPropertyName("unread_message_count")]
        public int UnreadMessageCount { get; set; }

        [JsonPropertyName("unread_notif_count")]
        public int UnreadNotifCount { get; set; }

        [JsonPropertyName("unseen_message_count")]
        public int UnseenMessageCount { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("verification_status")]
        public string VerificationStatus { get; set; }

        [JsonPropertyName("voip_info")]
        public VoipInfo VoipInfo { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("were_here_count")]
        public int WereHereCount { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


    }
    public class Business
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class CategoryList
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class ConnectedInstagramAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class ConnectedPageBackedInstagramAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Cover
    {
        [JsonPropertyName("cover_id")]
        public string CoverId { get; set; }

        [JsonPropertyName("offset_x")]
        public int OffsetX { get; set; }

        [JsonPropertyName("offset_y")]
        public int OffsetY { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class InstagramBusinessAccount
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }

    public class MessagingFeatureStatus
    {
        [JsonPropertyName("hop_v2")]
        public bool HopV2 { get; set; }
    }
    public class VoipInfo
    {
        [JsonPropertyName("has_permission")]
        public bool HasPermission { get; set; }

        [JsonPropertyName("has_mobile_app")]
        public bool HasMobileApp { get; set; }

        [JsonPropertyName("is_pushable")]
        public bool IsPushable { get; set; }

        [JsonPropertyName("is_callable")]
        public bool IsCallable { get; set; }

        [JsonPropertyName("is_callable_webrtc")]
        public bool IsCallableWebrtc { get; set; }

        [JsonPropertyName("reason_code")]
        public int ReasonCode { get; set; }

        [JsonPropertyName("reason_description")]
        public string ReasonDescription { get; set; }
    }
}
